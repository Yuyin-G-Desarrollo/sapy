Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Xml
Imports Tools



Public Class AltaPolizaForm

#Region "Variables"
    Private hora As Integer = 0
    Private minuto As Integer = 0
    Private segundo As Integer = 0
    Private milisegundo As Integer = 0

    Dim objBU As New Negocios.AltaPolizaBU
    Dim dtDatosPolizas As New DataTable
    Dim empresa As String
    Dim estatus As String
    Dim fechaDe As Date
    Dim fechaA As Date
    Dim tipo As Integer
    Dim empresaBD As String
    Dim servidorBD As String
    Dim contribuyentesID As String
    Dim doctoVentasID As String
    Dim empresaSAYContpaqSICY As Integer
    Dim ultimafecha As Date
    Dim subtotalAcumulado As Double = 0
    Dim ivaAcumulado As Double = 0
    Dim abonosAcumulado As Double = 0
    Dim cargosAcumulado As Double = 0
    Dim estamal As Boolean = False
    '(YazminR 09-11-2015)
    Dim tablaProveedores As New DataTable
    Dim tablaProv As New DataTable
    Dim primaryKey(0) As DataColumn
    Dim tipoPoliza1 As Integer = 0
    Dim hsXMLDañados As New HashSet(Of String)


#End Region


    Private Sub AltaPolizaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        LlenadoCombos()
        btnEnvioContp.Enabled = False
    End Sub

#Region "Llenar grid"

    Public Sub llenarTablaCompras()
        estamal = True
        ultimafecha = "01/01/1900"
        Dim tablaNombre As New DataTable
        tablaNombre = Nothing

        Dim nombre As String = ""
        fechaDe = dtpDe.Text
        fechaA = dtpAl.Text

        'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-11-2015)
        tablaProveedores = objBU.obtieneProveedores(servidorBD, empresaBD)

        primaryKey(0) = tablaProveedores.Columns(0)
        tablaProveedores.PrimaryKey = primaryKey

        tablaProv = objBU.cargarCuentaContableSayProveedorNueva2(empresaSAYContpaqSICY)

        Dim tabla As New DataTable
        Dim cuentaCompras As Double = 0
        Dim cuentaComprasDesc As String = ""
        Dim cuentaComprasSAYID As Integer = 0

        Dim cuentaIVA As Double = 0
        Dim cuentaIVADesc As String = ""
        Dim cuentaIVASAYID As Integer = 0

        tabla = objBU.cuentasGenerales(empresaSAYContpaqSICY, "COMPRAS", "", tipoPoliza1)
        If tabla.Rows.Count > 0 Then
            cuentaCompras = tabla.Rows(0).Item("cgen_cuenta")
            cuentaComprasDesc = tabla.Rows(0).Item("cgen_nombre")
            cuentaComprasSAYID = tabla.Rows(0).Item("cuentaSAYID")
        Else
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
            objMesj.ShowDialog()
            grdCompras.DataSource = Nothing
            btnEnvioContp.Enabled = False
            estamal = True
            Exit Sub
        End If

        If tabla.Rows.Count > 0 Then
            tabla = objBU.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_PAGO", "", tipoPoliza1)
            cuentaIVA = tabla.Rows(0).Item("cgen_cuenta")
            cuentaIVADesc = tabla.Rows(0).Item("cgen_nombre")
            cuentaIVASAYID = tabla.Rows(0).Item("cuentaSAYID")
        Else
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
            objMesj.ShowDialog()
            grdCompras.DataSource = Nothing
            btnEnvioContp.Enabled = False
            estamal = True
            Exit Sub
        End If

        'Agrega la fila de la cuenta materia prima
        tablaNombre = objBU.obtenerNombreCuentaContpaq(cuentaCompras, servidorBD, empresaBD)
        If tablaNombre.Rows.Count > 0 Then
            nombre = tablaNombre.Rows(0).Item("Nombre")
        Else
            nombre = cuentaComprasDesc
        End If

        'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-11-2015)

        dtDatosPolizas = objBU.CargaGridPolizaCompras(estatus, contribuyentesID, fechaDe.Date, fechaA.Date, cmbEmpresa.SelectedValue)
        Dim contador As Integer = 0
        If dtDatosPolizas.Rows.Count > 0 Then
            Dim listParametros As DataTable = dtDatosPolizas.Clone
            grdCompras.DataSource = listParametros

            abonosAcumulado = 0
            subtotalAcumulado = 0
            ivaAcumulado = 0


            For Each row As DataRow In dtDatosPolizas.Rows

                Dim listaEntidades As New Entidades.Polizas

                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = cuentaCompras
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PROVEEDOR").Value = cuentaComprasDesc
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CARGOS").Value = Math.Round(row.Item("SubTotal"), 2)
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("REFERENCIA").Value = row.Item("REFERENCIA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FECHA").Value = row.Item("FECHA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("UUID").Value = listaEntidades.Puuid
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FOLIO").Value = row.Item("FOLIO")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SUBTOTAL").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ABONOS").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaComprasSAYID
                If contador <= 3 Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.LightSteelBlue
                    contador += 1
                End If

                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = cuentaIVA
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PROVEEDOR").Value = cuentaIVADesc
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CARGOS").Value = Math.Round(row.Item("IVA"), 2)
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("REFERENCIA").Value = row.Item("REFERENCIA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FECHA").Value = row.Item("FECHA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("UUID").Value = listaEntidades.Puuid
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FOLIO").Value = row.Item("FOLIO")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SUBTOTAL").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ABONOS").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVASAYID


                If contador <= 3 Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.LightSteelBlue
                    contador += 1
                End If

                'Agrega la fila de la compra
                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = row.Item("CUENTA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PROVEEDOR").Value = row.Item("PROVEEDOR")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CARGOS").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ABONOS").Value = Math.Round(row.Item("ABONOS"), 2)
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FECHA").Value = row.Item("FECHA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("REFERENCIA").Value = row.Item("REFERENCIA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("NAVE").Value = row.Item("NAVE")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = Math.Round(row.Item("IVA"), 2)
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SUBTOTAL").Value = row.Item("SUBTOTAL")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("UUID").Value = row.Item("UUID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SERIE").Value = row.Item("SERIE")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FOLIO").Value = row.Item("FOLIO")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = row.Item("TipoMovimiento")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1

                If contador <= 3 Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.LightSteelBlue
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    contador += 2
                Else
                    contador = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                End If

                'Extre los datos del XML
                listaEntidades = extraerUUID(row.Item("RutaXML"))

                If Not IsNothing(listaEntidades) Then

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("UUID").Value = listaEntidades.Puuid.ToString.ToUpper
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SERIE").Value = listaEntidades.Pserie
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FOLIO").Value = listaEntidades.Pfolio

                End If

                ''Llena cuentas del proveedor
                llenarCuentasProveedoresOptimizado(row)

                'Suma de acumulados
                If row.Item("ABONOS").ToString <> "" Then
                    abonosAcumulado += row.Item("ABONOS")
                End If

                If row.Item("SUBTOTAL").ToString <> "" Then
                    subtotalAcumulado += row.Item("SUBTOTAL")
                End If

                If row.Item("IVA").ToString <> "" Then
                    ivaAcumulado += row.Item("IVA")
                End If

                If row.Item("FECHA") > ultimafecha Then
                    ultimafecha = row.Item("FECHA")
                End If
            Next

            ''Actualiza los totales 
            Dim contadorBanderas As Integer = 0
            lblTotalAbonos2.Text = 0
            lblTotalCargos2.Text = 0
            For Each row As UltraGridRow In grdCompras.Rows
                lblTotalAbonos2.Text = (Math.Round(CDbl(row.Cells("Abonos").Value), 2) + Math.Round(CDbl(lblTotalAbonos2.Text), 2)).ToString("C")
                lblTotalCargos2.Text = (Math.Round(CDbl(row.Cells("CARGOS").Value), 2) + Math.Round(CDbl(lblTotalCargos2.Text), 2)).ToString("C")
                If row.Cells("Bandera").Value = 0 Then
                    contadorBanderas += 1
                End If
            Next

            'Valida que los cargos y abonos sean iguales
            If lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "Los totales no concuerdan favor de verificarlos."
                objMesj.ShowDialog()
            End If

            If contadorBanderas > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                'Muestra mensaje si existen proveedores sin cuenta contable
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas.ToString + " proveedor sin cuenta contable" + vbNewLine + " Favor de relacionarlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas.ToString + " proveedores sin cuenta contable" + vbNewLine + " Favor de relacionarlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            Dim tablaSinXML As New DataTable
            tablaSinXML = objBU.CargaComprasSinComprobante(dtpDe.Value, dtpAl.Value, doctoVentasID)

            If estamal = False Then
                bloquearControles(False)
            Else
                bloquearControles(True)
            End If

            'Valida si hay compras sin XML
            If tablaSinXML.Rows.Count > 0 Then
                Dim confirmacion As New Tools.ConfirmarForm
                confirmacion.mensaje = "Se encontraron compras sin XML relacionado. ¿Desea ver la lista de documentos para cargar el XML?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim form As New RelacionComprobantesFiscalesForm
                    form.tipo_busqueda = 2
                    form.fechaInicio = dtpDe.Value
                    form.fechaFin = dtpAl.Value
                    form.empresaID = doctoVentasID
                    form.ShowDialog(Me)
                End If
            End If




        Else
            grdCompras.DataSource = Nothing
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "No hay información para mostrar"
            btnEnvioContp.Enabled = False
            bloquearControles(True)
            objMesj.ShowDialog()

            Dim tablaSinXML As New DataTable
            bloquearControles(True)
            tablaSinXML = objBU.CargaComprasSinComprobante(dtpDe.Value, dtpAl.Value, doctoVentasID)
            If tablaSinXML.Rows.Count > 0 Then
                Dim confirmacion As New Tools.ConfirmarForm
                confirmacion.mensaje = "Se encontraron compras sin XML relacionado. ¿Desea ver la lista de documentos para cargar el XML?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim form As New RelacionComprobantesFiscalesForm
                    'form.lista_Comprobantes = tablaSinXML
                    form.tipo_busqueda = 2
                    form.fechaInicio = dtpDe.Value
                    form.fechaFin = dtpAl.Value
                    form.empresaID = doctoVentasID
                    form.ShowDialog(Me)
                Else
                End If
            End If

        End If
        ' End If
    End Sub

    Public Sub llenarTablaDepositosIdedentificados()
        hsXMLDañados.Clear()
        Dim objBU As New Negocios.AltaPolizaBU
        estamal = False
        dtDatosPolizas = Nothing

        'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(11-01-2016)
        Dim tabla1 As DataTable
        Dim depotIdentificar As String = ""
        Dim depotIdentificarDesc As String = ""
        Dim depotIdentificarCuentaSAYID As String = ""
        Dim tipoPoliza As Integer
        tipoPoliza = CInt(cmbTipo.SelectedValue.ToString)

        tablaProveedores = objBU.validarclienteExisteSay2(empresaSAYContpaqSICY)

        primaryKey(0) = tablaProveedores.Columns(0)
        tablaProveedores.PrimaryKey = primaryKey

        tablaProv = objBU.cargarCuentaContableSayClienteNueva2(empresaSAYContpaqSICY)

        tabla1 = objBU.cuentasGenerales(empresaSAYContpaqSICY, "DEP_POR_IDENT", "", tipoPoliza1)

        If tabla1.Rows.Count > 0 Then
            depotIdentificar = tabla1.Rows(0).Item("cgen_cuenta")
            depotIdentificarDesc = tabla1.Rows(0).Item("cgen_nombre")
            depotIdentificarCuentaSAYID = tabla1.Rows(0).Item("cuentaSAYID")
        Else
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
            btnEnvioContp.Enabled = False
            objMesj.ShowDialog()
            estamal = True
            grdCompras.DataSource = Nothing
            Exit Sub
        End If

        'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(11-01-2016)
        dtDatosPolizas = objBU.cargarGridDepositosIdentificados(doctoVentasID, dtpDe.Value, dtpAl.Value, cmbEstatus.Text, tipoPoliza)
        ultimafecha = "01-01-1900"
        If dtDatosPolizas.Rows.Count > 0 Then
            Dim contador As Integer = 0
            Dim totalRows As Integer = 0
            Dim tabla As DataTable = dtDatosPolizas.Clone
            Dim color As Drawing.Color = Drawing.Color.White
            Dim rowRespaldo As DataRow = Nothing
            grdCompras.DataSource = tabla

            cargosAcumulado = 0
            ivaAcumulado = 0
            abonosAcumulado = 0

            totalRows = dtDatosPolizas.Rows.Count
            For Each row As DataRow In dtDatosPolizas.Rows
                Dim listaEntidades As New Entidades.Polizas
                Dim existe As Boolean = False

                If contador = 0 Then
                    rowRespaldo = row
                End If

                If row.Item("depositoID") = rowRespaldo.Item("depositoID") And contador = 0 Then
                    contador = 0
                ElseIf row.Item("depositoID") = rowRespaldo.Item("depositoID") And contador = 1 Then
                    contador = 1
                ElseIf row.Item("depositoID") <> rowRespaldo.Item("depositoID") Then
                    contador = 2
                End If

                If contador = 0 Then
                    'AGREGA CUENTA DE DEPOSITO POR IDENTIFICAR     
                    listaEntidades = extraerUUID(row.Item("XML"))
                    If listaEntidades.PrutaXML <> "" Then
                        hsXMLDañados.Add(listaEntidades.PrutaXML + "|Cliente|" + row.Item("Cliente") + "|" + CDate(row.Item("FechaDeposito")).ToShortDateString)
                    End If

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = depotIdentificar
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = depotIdentificarDesc
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Clienteid").Value = row.Item("Clienteid")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = CDate(row.Item("Fecha")).ToShortDateString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FechaDeposito").Value = CDate(row.Item("FechaDeposito")).ToShortDateString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("depositoID").Value = row.Item("depositoID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cobroid").Value = row.Item("Cobroid")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Xml").Value = row.Item("Xml")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Pdf").Value = row.Item("Pdf")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Tipomovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = row.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = CDate(row.Item("FechaDeposito")).ToShortDateString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = depotIdentificarCuentaSAYID

                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If

                    contador = 1
                ElseIf contador = 1 Then
                    listaEntidades = extraerUUID(rowRespaldo.Item("XML"))
                    If listaEntidades.PrutaXML <> "" Then
                        hsXMLDañados.Add(listaEntidades.PrutaXML + "|Cliente|" + row.Item("Cliente") + "|F-" + listaEntidades.Pserie.ToString.ToUpper.Trim + listaEntidades.Pfolio.ToUpper.ToUpper.Trim)
                    End If

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = rowRespaldo.Item("Cuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = rowRespaldo.Item("Cliente")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Clienteid").Value = rowRespaldo.Item("Clienteid")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = rowRespaldo.Item("Abonos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = rowRespaldo.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FechaDeposito").Value = rowRespaldo.Item("FechaDeposito")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("depositoID").Value = rowRespaldo.Item("depositoID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cobroid").Value = rowRespaldo.Item("Cobroid")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Xml").Value = rowRespaldo.Item("Xml")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Pdf").Value = rowRespaldo.Item("Pdf")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Tipomovimiento").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = rowRespaldo.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString.ToUpper.Trim + listaEntidades.Pfolio.ToUpper.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = rowRespaldo.Item("RFC")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = rowRespaldo.Item("cuentaSAYID")
                    rowRespaldo = row
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                    'llenarCuentasClientes(rowRespaldo)
                    llenarCuentasClientesOptimizado(rowRespaldo)


                ElseIf contador = 2 Then
                    listaEntidades = extraerUUID(rowRespaldo.Item("XML"))
                    If listaEntidades.PrutaXML <> "" Then
                        hsXMLDañados.Add(listaEntidades.PrutaXML + "|Cliente|" + row.Item("Cliente") + "|" + CDate(row.Item("FechaDeposito")).ToShortDateString)
                    End If
                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = rowRespaldo.Item("Cuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = rowRespaldo.Item("Cliente")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Clienteid").Value = rowRespaldo.Item("Clienteid")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = rowRespaldo.Item("Abonos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = rowRespaldo.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FechaDeposito").Value = rowRespaldo.Item("FechaDeposito")

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("depositoID").Value = rowRespaldo.Item("depositoID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cobroid").Value = rowRespaldo.Item("Cobroid")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Xml").Value = rowRespaldo.Item("Xml")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Pdf").Value = rowRespaldo.Item("Pdf")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Tipomovimiento").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = rowRespaldo.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = rowRespaldo.Item("bandera")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString.ToUpper.Trim + listaEntidades.Pfolio.ToUpper.ToUpper.Trim

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = rowRespaldo.Item("RFC")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = rowRespaldo.Item("cuentaSAYID")

                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                    'llenarCuentasClientes(rowRespaldo)
                    llenarCuentasClientesOptimizado(rowRespaldo)

                    If color = Drawing.Color.White Then
                        color = Drawing.Color.LightSteelBlue
                    Else
                        color = Drawing.Color.White
                    End If
                    listaEntidades = extraerUUID(row.Item("XML"))
                    If listaEntidades.PrutaXML <> "" Then
                        hsXMLDañados.Add(listaEntidades.PrutaXML + "|Cliente|" + row.Item("Cliente") + "|" + CDate(row.Item("FechaDeposito")).ToShortDateString)
                    End If

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = depotIdentificar
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = depotIdentificarDesc
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Clienteid").Value = row.Item("Clienteid")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FechaDeposito").Value = row.Item("FechaDeposito")

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("depositoID").Value = row.Item("depositoID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cobroid").Value = row.Item("Cobroid")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Xml").Value = row.Item("Xml")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Pdf").Value = row.Item("Pdf")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Tipomovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = row.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = CDate(row.Item("FechaDeposito")).ToShortDateString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = depotIdentificarCuentaSAYID
                    rowRespaldo = row
                    contador = 1
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                End If


                If totalRows > 0 Then
                    totalRows -= 1
                End If
                If totalRows = 0 Then
                    listaEntidades = extraerUUID(row.Item("XML"))
                    If listaEntidades.PrutaXML <> "" Then
                        hsXMLDañados.Add(listaEntidades.PrutaXML + "|Cliente|" + row.Item("Cliente") + "|F-" + listaEntidades.Pserie.ToString.ToUpper.Trim + listaEntidades.Pfolio.ToUpper.ToUpper.Trim)
                    End If

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("Cuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Clienteid").Value = row.Item("Clienteid")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("Abonos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = CDate(row.Item("Fecha")).ToShortDateString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FechaDeposito").Value = CDate(row.Item("FechaDeposito")).ToShortDateString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("depositoID").Value = row.Item("depositoID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cobroid").Value = row.Item("Cobroid")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Xml").Value = row.Item("Xml")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Pdf").Value = row.Item("Pdf")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString.ToUpper.Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Tipomovimiento").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = row.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString.ToUpper.Trim + listaEntidades.Pfolio.ToUpper.ToUpper.Trim

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = row.Item("cuentaSAYID")
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                    'llenarCuentasClientes(row)
                    llenarCuentasClientesOptimizado(rowRespaldo)
                End If

                If row.Item("FECHA") > ultimafecha Then
                    ultimafecha = row.Item("FECHA")
                End If


            Next
            cargosAcumulado += Math.Round(ivaAcumulado, 2)
            abonosAcumulado += Math.Round(ivaAcumulado, 2)

            lblTotalAbonos2.Text = 0
            lblTotalCargos2.Text = 0
            Dim contadorBanderas As Integer = 0
            For Each row As UltraGridRow In grdCompras.Rows
                lblTotalAbonos2.Text = (Math.Round(CDbl(row.Cells("Abonos").Value), 2) + Math.Round(CDbl(lblTotalAbonos2.Text), 2)).ToString("C")
                lblTotalCargos2.Text = (Math.Round(CDbl(row.Cells("CARGOS").Value), 2) + Math.Round(CDbl(lblTotalCargos2.Text), 2)).ToString("C")

                If row.Cells("Bandera").Value = 0 And row.Cells("Tipomovimiento").Value = 1 Then
                    contadorBanderas += 1
                End If
            Next

            If hsXMLDañados.Count > 0 Then
                If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "Se encontraron XML dañados, por favor reemplácelos y vuelva a consultar la información de la póliza.") Then
                    Dim objReemplazarXMLDañados As New ReemplazarXMLDañadosForm
                    objReemplazarXMLDañados.hsXMLDañados = hsXMLDañados
                    objReemplazarXMLDañados.StartPosition = FormStartPosition.CenterScreen
                    objReemplazarXMLDañados.ShowDialog()
                End If

                estamal = True
            ElseIf lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "Los totales en abonos y cargos no coinciden."
                btnEnvioContp.Enabled = False
                estamal = True
                objMesj.ShowDialog()
            End If

            If contadorBanderas > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas.ToString + " cliente sin cuenta contable" + vbNewLine + " Favor de relacionarlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas.ToString + " clientes sin cuenta contable" + vbNewLine + " Favor de relacionarlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If estamal = False Then
                bloquearControles(False)
            Else
                bloquearControles(True)
            End If

        Else
            btnEnvioContp.Enabled = False
            grdCompras.DataSource = Nothing
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "No hay información para mostrar"
            btnEnvioContp.Enabled = False
            objMesj.ShowDialog()
        End If


    End Sub

    Public Sub llenarTablaDepositosIdentificar()
        hsXMLDañados.Clear()
        Dim objBU As New Negocios.AltaPolizaBU
        estamal = False
        dtDatosPolizas = Nothing

        'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(12-01-2016)
        Dim tablaCuentasG, tabla1 As DataTable
        tablaCuentasG = objBU.cuentasGeneralesBancos(empresaSAYContpaqSICY, "BANCOS", "DEPÓSITOS POR IDENTIFICAR")
        primaryKey(0) = tablaCuentasG.Columns(6)
        tablaCuentasG.PrimaryKey = primaryKey

        'AGREGA CUENTA DE IVA PENDIENTE DE COBRO
        Dim ivaPCobro As String = ""
        Dim ivaPCobroDesc As String = ""
        Dim ivaPCobroSAYID As Integer = 0
        tabla1 = objBU.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_COBRO", "", tipoPoliza1)
        If tabla1.Rows.Count > 0 Then
            ivaPCobro = tabla1.Rows(0).Item("cgen_cuenta")
            ivaPCobroDesc = tabla1.Rows(0).Item("cgen_nombre")
            ivaPCobroSAYID = tabla1.Rows(0).Item("cuentaSAYID")
        Else
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
            btnEnvioContp.Enabled = False
            objMesj.ShowDialog()
            grdCompras.DataSource = Nothing
            estamal = True
            Exit Sub
        End If

        'AGREGA CUENTA DE IVA TRASLADADO
        Dim ivaTrasladado As String = ""
        Dim ivaTrasladadoDesc As String = ""
        Dim ivaTrasladadoSAYID As Integer = 0
        tabla1 = objBU.cuentasGenerales(empresaSAYContpaqSICY, "IVA_TRAS", "", tipoPoliza1
                                        )
        If tabla1.Rows.Count > 0 Then
            ivaTrasladado = tabla1.Rows(0).Item("cgen_cuenta")
            ivaTrasladadoDesc = tabla1.Rows(0).Item("cgen_nombre")
            ivaTrasladadoSAYID = tabla1.Rows(0).Item("cuentaSAYID")
        Else
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
            btnEnvioContp.Enabled = False
            objMesj.ShowDialog()
            grdCompras.DataSource = Nothing
            estamal = True
            Exit Sub
        End If

        'AGREGA CUENTA DE DEPOSITO POR IDENTIFICAR
        Dim depotIdentificar As String = ""
        Dim depotIdentificarDesc As String = ""
        Dim depotIdentificarSAYID As Integer = 0
        tabla1 = objBU.cuentasGenerales(empresaSAYContpaqSICY, "DEP_POR_IDENT", "", tipoPoliza1)
        If tabla1.Rows.Count > 0 Then
            depotIdentificar = tabla1.Rows(0).Item("cgen_cuenta")
            depotIdentificarDesc = tabla1.Rows(0).Item("cgen_nombre")
            depotIdentificarSAYID = tabla1.Rows(0).Item("cuentaSAYID")
        Else
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
            btnEnvioContp.Enabled = False
            objMesj.ShowDialog()
            grdCompras.DataSource = Nothing
            estamal = True
            Exit Sub
        End If

        'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(12-01-2016)

        dtDatosPolizas = objBU.cargarGridDepositosPorIdentificar(doctoVentasID, dtpDe.Value, dtpAl.Value, cmbEstatus.Text)

        If dtDatosPolizas.Rows.Count > 0 Then
            Dim contador As Integer = 0
            Dim tabla As DataTable = dtDatosPolizas.Clone
            Dim cuentaBancos As String = ""
            Dim cuentaBancosDesc As String = ""
            Dim cuentaBancosSAYID As String = ""
            Dim tipoPolizaContpaqID As Integer = 0
            Dim row1 As DataRow
            grdCompras.DataSource = tabla

            cargosAcumulado = 0
            ivaAcumulado = 0
            abonosAcumulado = 0

            For Each row As DataRow In dtDatosPolizas.Rows

                'AGREGA CARGO AL BANCO
                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = row.Item("CUENTA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("BANCO").Value = row.Item("BANCO")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CARGOS").Value = row.Item("CARGOS")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ABONOS").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FECHA").Value = row.Item("FECHA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTAID").Value = row.Item("CUENTAID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTOID").Value = row.Item("MOVIMIENTOID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTABANCARIA").Value = row.Item("CUENTABANCARIA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                cuentaBancos = row.Item("CUENTABANCARIA").ToString.Replace("-", "").Trim

                row1 = tablaCuentasG.Rows.Find(cuentaBancos)

                If row1 Is Nothing Then
                    Dim objMesj As New Tools.AdvertenciaForm
                    objMesj.mensaje = "Favor dar de alta la cuenta bancaria (" + row.Item("CuentaBancaria") + ")"
                    btnEnvioContp.Enabled = False
                    objMesj.ShowDialog()
                    estamal = True
                    Exit Sub
                Else
                    cuentaBancos = ""
                    cuentaBancosDesc = ""
                    cuentaBancos = row1.Item("cgen_cuenta")
                    cuentaBancosDesc = row1.Item("CuentaBancaria")
                    cuentaBancosSAYID = row1.Item("cuentaSAYID")
                    tipoPolizaContpaqID = row1.Item("tipoPolizaCompaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = cuentaBancos
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("BANCO").Value = cuentaBancosDesc
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaBancosSAYID
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("tipoPolizaContpaqID").Value = tipoPolizaContpaqID
                End If


                'tabla = Nothing
                'tabla = objBU.cuentasGenerales(empresaSAYContpaqSICY, "BANCOS", cuentaBancos)
                'If tabla.Rows.Count > 0 Then
                '    cuentaBancos = ""
                '    cuentaBancosDesc = ""
                '    cuentaBancos = tabla.Rows(0).Item("cgen_cuenta")
                '    cuentaBancosDesc = tabla.Rows(0).Item("CuentaBancaria")
                '    cuentaBancosSAYID = tabla.Rows(0).Item("cuentaSAYID")
                '    tipoPolizaContpaqID = tabla.Rows(0).Item("tipoPolizaCompaqID")
                '    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = cuentaBancos
                '    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("BANCO").Value = cuentaBancosDesc
                '    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaBancosSAYID
                '    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("tipoPolizaContpaqID").Value = tipoPolizaContpaqID

                'Else
                '    Dim objMesj As New Tools.AdvertenciaForm
                '    objMesj.mensaje = "Favor dar de alta la cuenta bancaria (" + row.Item("CuentaBancaria") + ")"
                '    btnEnvioContp.Enabled = False
                '    objMesj.ShowDialog()
                '    estamal = True
                '    Exit Sub
                'End If

                If contador <= 4 Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.LightSteelBlue
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    contador += 1
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                End If


                'AGREGA CUENTA DE IVA PENDIENTE DE COBRO
                'Dim ivaPCobro As String = ""
                'Dim ivaPCobroDesc As String = ""
                'Dim ivaPCobroSAYID As Integer = 0
                'tabla = objBU.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_COBRO", "")
                'If tabla.Rows.Count > 0 Then
                '    ivaPCobro = tabla.Rows(0).Item("cgen_cuenta")
                '    ivaPCobroDesc = tabla.Rows(0).Item("cgen_nombre")
                '    ivaPCobroSAYID = tabla.Rows(0).Item("cuentaSAYID")
                'Else
                '    Dim objMesj As New Tools.AdvertenciaForm
                '    objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
                '    btnEnvioContp.Enabled = False
                '    objMesj.ShowDialog()
                '    grdCompras.DataSource = Nothing
                '    estamal = True
                '    Exit Sub
                'End If

                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("BANCO").Value = ivaPCobroDesc
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = ivaPCobro
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CARGOS").Value = Math.Round((row.Item("CARGOS") / 1.16) * 0.16, 2)
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTABANCARIA").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ABONOS").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTOID").Value = row.Item("MOVIMIENTOID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FECHA").Value = row.Item("FECHA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = ivaPCobroSAYID
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("tipoPolizaContpaqID").Value = ""
                If contador <= 4 Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.LightSteelBlue
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    contador += 1
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                End If

                'AGREGA CUENTA DE IVA TRASLADADO
                'Dim ivaTrasladado As String = ""
                'Dim ivaTrasladadoDesc As String = ""
                'Dim ivaTrasladadoSAYID As Integer = 0
                'tabla = objBU.cuentasGenerales(empresaSAYContpaqSICY, "IVA_TRAS", "")
                'If tabla.Rows.Count > 0 Then
                '    ivaTrasladado = tabla.Rows(0).Item("cgen_cuenta")
                '    ivaTrasladadoDesc = tabla.Rows(0).Item("cgen_nombre")
                '    ivaTrasladadoSAYID = tabla.Rows(0).Item("cuentaSAYID")
                'Else
                '    Dim objMesj As New Tools.AdvertenciaForm
                '    objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
                '    btnEnvioContp.Enabled = False
                '    objMesj.ShowDialog()
                '    grdCompras.DataSource = Nothing
                '    estamal = True
                '    Exit Sub
                'End If
                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("BANCO").Value = ivaTrasladadoDesc
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = ivaTrasladado
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ABONOS").Value = Math.Round((row.Item("CARGOS") / 1.16) * 0.16, 2)
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CARGOS").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 1
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTOID").Value = row.Item("MOVIMIENTOID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FECHA").Value = row.Item("FECHA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = ivaTrasladadoSAYID
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("tipoPolizaContpaqID").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTABANCARIA").Value = ""
                If contador <= 4 Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.LightSteelBlue
                    contador += 1
                End If

                ''AGREGA CUENTA DE DEPOSITO POR IDENTIFICAR
                'Dim depotIdentificar As String = ""
                'Dim depotIdentificarDesc As String = ""
                'Dim depotIdentificarSAYID As Integer = 0
                'tabla = objBU.cuentasGenerales(empresaSAYContpaqSICY, "DEP_POR_IDENT", "")
                'If tabla.Rows.Count > 0 Then
                '    depotIdentificar = tabla.Rows(0).Item("cgen_cuenta")
                '    depotIdentificarDesc = tabla.Rows(0).Item("cgen_nombre")
                '    depotIdentificarSAYID = tabla.Rows(0).Item("cuentaSAYID")
                'Else
                '    Dim objMesj As New Tools.AdvertenciaForm
                '    objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
                '    btnEnvioContp.Enabled = False
                '    objMesj.ShowDialog()
                '    grdCompras.DataSource = Nothing
                '    estamal = True
                '    Exit Sub
                'End If

                grdCompras.DisplayLayout.Bands(0).AddNew()

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("BANCO").Value = depotIdentificarDesc
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = depotIdentificar
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ABONOS").Value = row.Item("CARGOS")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CARGOS").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 1
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTOID").Value = row.Item("MOVIMIENTOID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FECHA").Value = row.Item("FECHA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = depotIdentificarSAYID
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("tipoPolizaContpaqID").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTABANCARIA").Value = ""
                If contador <= 4 Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.LightSteelBlue
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    contador += 2
                Else
                    contador = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                End If

                ivaAcumulado += (row.Item("CARGOS") / 1.16) * 0.16
                abonosAcumulado += row.Item("CARGOS")
                cargosAcumulado += row.Item("CARGOS")
                ultimafecha = row.Item("FECHA")
            Next
            cargosAcumulado += Math.Round(ivaAcumulado, 2)
            abonosAcumulado += Math.Round(ivaAcumulado, 2)
            lblTotalAbonos2.Text = 0
            lblTotalCargos2.Text = 0
            For Each row As UltraGridRow In grdCompras.Rows
                lblTotalAbonos2.Text = (Math.Round(CDbl(row.Cells("Abonos").Value), 2) + Math.Round(CDbl(lblTotalAbonos2.Text), 2)).ToString("C")
                lblTotalCargos2.Text = (Math.Round(CDbl(row.Cells("CARGOS").Value), 2) + Math.Round(CDbl(lblTotalCargos2.Text), 2)).ToString("C")
            Next


            If hsXMLDañados.Count > 0 Then
                If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "Se encontraron XML dañados, por favor reemplácelos y vuelva a consultar la información de la póliza.") Then
                    Dim objReemplazarXMLDañados As New ReemplazarXMLDañadosForm
                    objReemplazarXMLDañados.hsXMLDañados = hsXMLDañados
                    objReemplazarXMLDañados.StartPosition = FormStartPosition.CenterScreen
                    objReemplazarXMLDañados.ShowDialog()
                End If

                estamal = True
            ElseIf lblTotalAbonos2.Text <> lblTotalCargos2.Text And hsXMLDañados.Count = 0 Then
                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "Los totales en abonos y cargos no coinciden."
                btnEnvioContp.Enabled = False
                estamal = True
                objMesj.ShowDialog()

            End If

            If estamal = False Then
                bloquearControles(False)
            Else
                bloquearControles(True)
            End If


        Else
            btnEnvioContp.Enabled = False
            grdCompras.DataSource = Nothing
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "No hay información para mostrar"
            btnEnvioContp.Enabled = False
            objMesj.ShowDialog()
        End If
    End Sub

    Public Sub llenarTablaTransferencias()
        hsXMLDañados.Clear()
        ultimafecha = "01/01/1900"
        estamal = False
        Dim objBU As New Negocios.AltaPolizaBU
        Dim contador As Integer = 0
        Dim listaEntidades As New Entidades.Polizas

        'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(13-11-2015)
        tablaProveedores = objBU.obtieneProveedores(servidorBD, empresaBD)

        primaryKey(0) = tablaProveedores.Columns(0)
        tablaProveedores.PrimaryKey = primaryKey

        tablaProv = objBU.cargarCuentaContableSayProveedorNueva2(empresaSAYContpaqSICY)

        'BUSCA CUENTAS GENERALES DE LA EMPRESA PARA POLIZA DE TRANSFERENCIAS
        Dim tabla As New DataTable
        Dim cuentaIVAPenPago As Double = 0
        Dim cuentaIVAPenPagoDesc As String = ""
        Dim cuentaIVAPenPagoSAYID As Integer = 0
        Dim cuentaIVA As Double = 0
        Dim cuentaIVADesc As String = ""
        Dim cuentaIVASAYID As Integer = 0

        tabla = objBU.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_PAGO", "", tipoPoliza1)
        If tabla.Rows.Count > 0 Then
            cuentaIVAPenPago = tabla.Rows(0).Item("cgen_cuenta")
            cuentaIVAPenPagoDesc = tabla.Rows(0).Item("cgen_nombre")
            cuentaIVAPenPagoSAYID = tabla.Rows(0).Item("cuentaSAYID")
        Else
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
            btnEnvioContp.Enabled = False
            objMesj.ShowDialog()
            grdCompras.DataSource = Nothing
            estamal = True
            Exit Sub
        End If

        tabla = objBU.cuentasGenerales(empresaSAYContpaqSICY, "IVA_ACRE_PAGADO", "", tipoPoliza1)
        If tabla.Rows.Count > 0 Then
            cuentaIVA = tabla.Rows(0).Item("cgen_cuenta")
            cuentaIVADesc = tabla.Rows(0).Item("cgen_nombre")
            cuentaIVASAYID = tabla.Rows(0).Item("cuentaSAYID")
        Else
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
            btnEnvioContp.Enabled = False
            objMesj.ShowDialog()
            estamal = True
            grdCompras.DataSource = Nothing
            Exit Sub
        End If

        'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(13-11-2015)

        dtDatosPolizas = objBU.cargarGridTransferencias(dtpDe.Value, dtpAl.Value, doctoVentasID, estatus)

        If dtDatosPolizas.Rows.Count > 0 Then
            Dim listParametros As DataTable = dtDatosPolizas.Clone
            grdCompras.DataSource = listParametros

            abonosAcumulado = 0
            subtotalAcumulado = 0
            ivaAcumulado = 0

            Dim color As New System.Drawing.Color
            Dim movimiento As Integer = 0
            color = Drawing.Color.White

            Dim referencia As String = ""
            For Each row As DataRow In dtDatosPolizas.Rows
                referencia = row.Item("REFERENCIA").ToString
                referencia = referencia.Trim

                If row.Item("FECHA") > ultimafecha Then
                    ultimafecha = row.Item("FECHA")
                End If

                If row.Item("RutaXML").ToString.Length > 0 Then
                    'ES UN MOVIMIENTO FACTURA
                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    movimiento += 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = movimiento
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = row.Item("CUENTA")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PROVEEDOR").Value = row.Item("PROVEEDOR")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CARGOS").Value = Math.Round(row.Item("CARGOS"), 2)
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ABONOS").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FECHA").Value = dtpDe.Value
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("UUID").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("REFERENCIA").Value = row.Item("REFERENCIA").ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("idTransferencia").Value = row.Item("idTransferencia")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SUBTOTAL").Value = Math.Round(row.Item("SUBTOTAL"), 2)
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = Math.Round(row.Item("IVA"), 2)
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaBancaria").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RazonSocialP").Value = row.Item("RazonSocialP")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("importeTransferencia").Value = row.Item("importeTransferencia")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML").ToString.ToUpper
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF").ToString.ToUpper
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SERIE").Value = row.Item("SERIE")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FOLIO").Value = row.Item("FOLIO")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("NAVE").Value = row.Item("NAVE")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClabeInterbancaria").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("NumAutorizacion").Value = row.Item("NumAutorizacion")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("tipoPolizaContpaqID").Value = ""

                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(row.Item("RutaXML"))

                    If listaEntidades.PrutaXML <> "" Then
                        hsXMLDañados.Add(listaEntidades.PrutaXML + "|Proveedor|" + row.Item("Proveedor") + "|" + row.Item("REFERENCIA").ToString)
                    End If

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("UUID").Value = listaEntidades.Puuid.ToString.ToUpper
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SERIE").Value = listaEntidades.Pserie
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FOLIO").Value = listaEntidades.Pfolio

                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color

                    llenarCuentasProveedoresOptimizado(row)
                Else

                    'ES LA TRANSFERENCIA
                    ''agrega fila cuenta IVA ACREDITADO
                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    movimiento += 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = movimiento
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = cuentaIVA
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PROVEEDOR").Value = cuentaIVADesc
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ABONOS").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CARGOS").Value = Math.Round(row.Item("IVA"), 2)
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("RFC").ToString.Replace("-", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SUBTOTAL").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("REFERENCIA").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FECHA").Value = dtpDe.Value
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("UUID").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SERIE").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FOLIO").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("idTransferencia").Value = row.Item("idTransferencia")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClabeInterbancaria").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RazonSocialP").Value = row.Item("RazonSocialP")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("NumAutorizacion").Value = row.Item("NumAutorizacion")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVASAYID
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("tipoPolizaContpaqID").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaBancaria").Value = ""
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If

                    ''agrega fila cuenta IVA POR ACREDITAR
                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    movimiento += 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = movimiento
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = cuentaIVAPenPago
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PROVEEDOR").Value = cuentaIVAPenPagoDesc
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ABONOS").Value = Math.Round(row.Item("IVA"), 2)
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CARGOS").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SUBTOTAL").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("REFERENCIA").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FECHA").Value = dtpDe.Value
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("UUID").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SERIE").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FOLIO").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("idTransferencia").Value = row.Item("idTransferencia")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClabeInterbancaria").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RazonSocialP").Value = row.Item("RazonSocialP")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("NumAutorizacion").Value = row.Item("NumAutorizacion")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = "Valio"
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVAPenPagoSAYID
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("tipoPolizaContpaqID").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaBancaria").Value = ""

                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If

                    ''agrega fila del abono del banco

                    Dim cuentaBancos As String = ""
                    Dim cuentaBancosDesc As String = ""
                    Dim cuda_cuentacontpaqid As String = ""
                    Dim cuda_bancocontpaqid As String = ""
                    Dim cuentaBancosSAYID As Integer = 0
                    Dim tipoPolizaContpaqID As Integer
                    'B.cuda_cuentacontpaqid,B.cuda_bancocontpaqid
                    If row.Item("CuentaBancaria").ToString.Length > 0 Then
                        tabla = objBU.cuentasGenerales(empresaSAYContpaqSICY, "BANCOS", row.Item("CuentaBancaria").replace("-", ""), tipoPoliza1)
                        If tabla.Rows.Count > 0 Then
                            cuentaBancos = tabla.Rows(0).Item("cgen_cuenta")
                            cuentaBancosDesc = tabla.Rows(0).Item("CuentaBancaria")
                            cuda_cuentacontpaqid = tabla.Rows(0).Item("CuentaContpaqid")
                            cuda_bancocontpaqid = tabla.Rows(0).Item("bancoContpaqid")
                            cuentaBancosSAYID = tabla.Rows(0).Item("cuentaSAYID")
                            tipoPolizaContpaqID = tabla.Rows(0).Item("tipoPolizaCompaqID")
                        Else
                            Dim objMesj As New Tools.AdvertenciaForm
                            objMesj.mensaje = "Favor dar de alta la cuenta bancaria (" + row.Item("CuentaBancaria") + ")"
                            objMesj.ShowDialog()
                            btnEnvioContp.Enabled = False
                            Exit Sub
                        End If
                    End If

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    movimiento += 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = movimiento
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = cuentaBancos
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PROVEEDOR").Value = cuentaBancosDesc
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ABONOS").Value = Math.Round(row.Item("ABONOS"), 2)
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CARGOS").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SUBTOTAL").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CONCEPTO").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("REFERENCIA").Value = row.Item("NumAutorizacion")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FECHA").Value = dtpDe.Value
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("UUID").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SERIE").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FOLIO").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("idTransferencia").Value = row.Item("idTransferencia")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClabeInterbancaria").Value = row.Item("ClabeInterbancaria")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaContpaqid").Value = cuda_cuentacontpaqid
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bancoContpaqid").Value = cuda_bancocontpaqid
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaBancaria").Value = row.Item("CuentaBancaria")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RazonSocialP").Value = row.Item("RazonSocialP")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("NumAutorizacion").Value = row.Item("NumAutorizacion")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaBancosSAYID
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("tipoPolizaContpaqID").Value = tipoPolizaContpaqID

                    tabla = Nothing
                    tabla = objBU.obtenerNombreCuentaContpaq(grdCompras.Rows(grdCompras.Rows.Count - 4).Cells("CUENTA").Value, servidorBD, empresaBD)
                    If tabla.Rows.Count > 0 Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = tabla.Rows(0).Item("Nombre")
                        grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("Concepto").Value = tabla.Rows(0).Item("Nombre")
                    End If

                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If

                    If color = Drawing.Color.White Then
                        color = Drawing.Color.LightSteelBlue
                    Else
                        color = Drawing.Color.White
                    End If
                    movimiento = 0
                End If

                If row.Item("ABONOS").ToString <> "" Then
                    abonosAcumulado += row.Item("ABONOS")
                End If

                If row.Item("SUBTOTAL").ToString <> "" Then
                    subtotalAcumulado += row.Item("SUBTOTAL")
                End If

                If row.Item("IVA").ToString <> "" Then
                    ivaAcumulado += row.Item("IVA")
                End If

                If row.Item("CARGOS").ToString <> "" Then
                    cargosAcumulado += row.Item("CARGOS")
                End If
            Next

            Dim contadorBanderas As Integer = 0
            lblTotalAbonos2.Text = 0
            lblTotalCargos2.Text = 0

            For Each row As UltraGridRow In grdCompras.Rows
                lblTotalAbonos2.Text = (Math.Round(CDbl(row.Cells("Abonos").Value), 2) + Math.Round(CDbl(lblTotalAbonos2.Text), 2)).ToString("C")
                lblTotalCargos2.Text = (Math.Round(CDbl(row.Cells("CARGOS").Value), 2) + Math.Round(CDbl(lblTotalCargos2.Text), 2)).ToString("C")
                If row.Cells("Bandera").Value = 0 Then
                    contadorBanderas += 1
                End If
            Next

            'CODIGO QUE ENVIAR DATATABLE A PANTALLA DE VALENTIN
            If lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "Los totales en abonos y cargos no coinciden."
                btnEnvioContp.Enabled = False
                estamal = True
                objMesj.ShowDialog()
            End If

            If contadorBanderas > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas.ToString + " proveedor sin cuenta contable" + vbNewLine + " Favor de relacionarlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas.ToString + " proveedores sin cuenta contable" + vbNewLine + " Favor de relacionarlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            Dim tablaSinXML As New DataTable
            bloquearControles(True)
            tablaSinXML = objBU.buscaDocumentosSinXML_Transferencias(dtpDe.Value, dtpAl.Value, doctoVentasID)

            If hsXMLDañados.Count > 0 Then
                If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "Se encontraron XML dañados, por favor reemplácelos y vuelva a consultar la información de la póliza.") Then
                    Dim objReemplazarXMLDañados As New ReemplazarXMLDañadosForm
                    objReemplazarXMLDañados.hsXMLDañados = hsXMLDañados
                    objReemplazarXMLDañados.StartPosition = FormStartPosition.CenterScreen
                    objReemplazarXMLDañados.ShowDialog()
                End If

                estamal = True
            ElseIf tablaSinXML.Rows.Count > 0 Then
                Dim confirmacion As New Tools.ConfirmarForm
                confirmacion.mensaje = "Se encontraron transferencias con documentos sin XML relacionado. ¿Desea ver la lista de documentos para cargar el XML?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim form As New RelacionComprobantesFiscalesForm
                    'form.lista_Comprobantes = tablaSinXML
                    form.tipo_busqueda = 1
                    form.fechaInicio = dtpDe.Value
                    form.fechaFin = dtpAl.Value
                    form.empresaID = doctoVentasID
                    form.ShowDialog(Me)
                End If

            End If

            If estamal = False Then
                bloquearControles(False)
            Else
                bloquearControles(True)
            End If

        Else
            btnEnvioContp.Enabled = False
            grdCompras.DataSource = Nothing
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "No hay información para mostrar"
            btnEnvioContp.Enabled = False
            bloquearControles(True)
            objMesj.ShowDialog()

            Dim tablaSinXML As New DataTable
            bloquearControles(True)
            tablaSinXML = objBU.buscaDocumentosSinXML_Transferencias(dtpDe.Value, dtpAl.Value, doctoVentasID)
            If tablaSinXML.Rows.Count > 0 Then
                Dim confirmacion As New Tools.ConfirmarForm
                confirmacion.mensaje = "Se encontraron transferencias con documentos sin XML relacionado. ¿Desea ver la lista de documentos para cargar el XML?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim form As New RelacionComprobantesFiscalesForm

                    form.tipo_busqueda = 1
                    form.fechaInicio = dtpDe.Value
                    form.fechaFin = dtpAl.Value
                    form.empresaID = doctoVentasID
                    form.ShowDialog(Me)
                Else

                End If
            End If


        End If
    End Sub

    Public Sub llenarTablaVentas()
        hsXMLDañados.Clear()
        ultimafecha = "01-01-1900"
        estamal = False
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim tablaVentas As New DataTable
        Dim tablaCuentasGenerales As New DataTable
        Dim advertencia As New AdvertenciaForm

        Dim cuentaVentasConIva As String = String.Empty
        Dim cuentaVentasDescConIva As String = String.Empty
        Dim cuentaVentasConIvaSAYID As String = ""

        Dim cuentaVentasSinIva As String = String.Empty
        Dim cuentaVentasDescSinIva As String = String.Empty
        Dim cuentaVentasSinIvaSAYID As String = ""

        Dim cuentaIVA As String = String.Empty
        Dim cuentaIVADesc As String = String.Empty
        Dim cuentaIVASayID As String = ""

        Dim color As New System.Drawing.Color
        color = Drawing.Color.White
        fechaDe = dtpDe.Text
        fechaA = dtpAl.Text

        'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(16-11-2015)

        tablaProveedores = objBu.validarclienteExisteSay2(empresaSAYContpaqSICY)

        primaryKey(0) = tablaProveedores.Columns(0)
        tablaProveedores.PrimaryKey = primaryKey

        tablaProv = objBu.cargarCuentaContableSayClienteNueva2(empresaSAYContpaqSICY)

        'BUSCA LA CUENTA GENERAL DE VENTAS CON/SIN IVA
        tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "VENTAS_CON_IVA", "", tipoPoliza1)
        If tablaCuentasGenerales.Rows.Count > 0 Then
            cuentaVentasConIva = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
            cuentaVentasDescConIva = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
            cuentaVentasConIvaSAYID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
        Else
            advertencia.mensaje = "Favor de dar de alta la cuenta de ventas para esta empresa."
            advertencia.ShowDialog()
            grdCompras.DataSource = Nothing
            btnEnvioContp.Enabled = False
            estamal = True
            Exit Sub
        End If

        'BUSCA LA CUENTA GENERAL DE IVA PENDIENTE DE COBRO
        tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_COBRO", "", tipoPoliza1)
        If tablaCuentasGenerales.Rows.Count > 0 Then
            cuentaIVA = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
            cuentaIVADesc = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
            cuentaIVASayID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
        Else
            advertencia.mensaje = "Favor de dar de alta la cuenta de IVA pendiente de cobro para esta empresa."
            advertencia.ShowDialog()
            grdCompras.DataSource = Nothing
            btnEnvioContp.Enabled = False
            estamal = True
            Exit Sub
        End If
        'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(16-11-2015)

        tablaVentas = objBu.CargaGridPolizaVentas(estatus, doctoVentasID, fechaDe.Date, fechaA.Date, cmbEmpresa.SelectedValue)
        If tablaVentas.Rows.Count > 0 Then

            'tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "VENTAS_SIN_IVA", "")

            'If tablaCuentasGenerales.Rows.Count > 0 Then
            '    cuentaVentasSinIva = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
            '    cuentaVentasDescSinIva = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
            '    cuentaVentasSinIvaSAYID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
            'Else
            '    advertencia.mensaje = "Favor de dar de alta la cuenta de ventas para esta empresa."
            '    advertencia.ShowDialog()
            '    grdCompras.DataSource = Nothing
            '    btnEnvioContp.Enabled = False
            '    Exit Sub
            'End If

            Dim listParametros As DataTable = tablaVentas.Clone
            grdCompras.DataSource = listParametros
            For Each row As DataRow In tablaVentas.Rows

                'AGREGA CARGO A CUENTA DEL CLIENTE

                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                'BUSCAR UUID
                Dim polizaVentas As New Entidades.Polizas
                polizaVentas = extraerUUID(row.Item("rutaXML"))

                If polizaVentas.PrutaXML <> "" Then
                    hsXMLDañados.Add(polizaVentas.PrutaXML + "|Cliente|" + row.Item("Cliente") + "|" + row.Item("Referencia"))
                End If

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = polizaVentas.Puuid
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = polizaVentas.Pserie
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = polizaVentas.Pfolio
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = row.Item("Referencia")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "0"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaXML").Value = row.Item("rutaXML")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaPDF").Value = row.Item("rutaPDF")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteId").Value = row.Item("ClienteId")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdVenta").Value = row.Item("IdVenta")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SubTotal").Value = row.Item("SubTotal")

                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                End If

                'llenarCuentasClientes(row)
                llenarCuentasClientesOptimizado(row)

                'AGREGA ABONO A LA CUENTA DE VENTAS
                'row.Item("Cargos")
                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = (row.Item("Cargos") / 1.16)
                If row.Item("IVA") > 0 Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaVentasConIva
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = cuentaVentasDescConIva
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaVentasConIvaSAYID
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaVentasSinIva
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = cuentaVentasDescSinIva
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaVentasSinIvaSAYID
                End If

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = polizaVentas.Puuid
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = polizaVentas.Pserie
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = polizaVentas.Pfolio
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = row.Item("Referencia")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "1"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = "1"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaXML").Value = row.Item("rutaXML")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaPDF").Value = row.Item("rutaPDF")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteId").Value = row.Item("ClienteId")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdVenta").Value = row.Item("IdVenta")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SubTotal").Value = row.Item("SubTotal")



                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                End If

                'AGREGA ABONO A IVA PENDIENTE DE COBRO

                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = cuentaIVADesc
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaIVA
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = ((row.Item("Cargos") / 1.16) * 0.16)
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = polizaVentas.Puuid
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = polizaVentas.Pserie
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = polizaVentas.Pfolio
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = row.Item("Referencia")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "1"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = "1"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaXML").Value = row.Item("rutaXML")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaPDF").Value = row.Item("rutaPDF")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteId").Value = row.Item("ClienteId")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdVenta").Value = row.Item("IdVenta")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVASayID
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SubTotal").Value = row.Item("SubTotal")
                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    color = Drawing.Color.LightSteelBlue
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    color = Drawing.Color.White
                End If

                If grdCompras.Rows(grdCompras.Rows.Count - 3).Cells("Cuenta").Value <> "" Then
                    Dim obBUNombre As New Contabilidad.Negocios.AltaPolizaBU
                    Dim tablaNombre As New DataTable
                    tablaNombre = obBUNombre.obtenerNombreCuentaContpaq(grdCompras.Rows(grdCompras.Rows.Count - 3).Cells("Cuenta").Value, servidorBD, empresaBD)
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = tablaNombre.Rows(0).Item("Nombre")
                    grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("Concepto").Value = tablaNombre.Rows(0).Item("Nombre")
                End If

                If row.Item("FECHA") > ultimafecha Then
                    ultimafecha = row.Item("FECHA")
                End If
            Next

            Dim contadorBanderas As Integer = 0
            Dim contadorBanderas2 As Integer = 0
            lblTotalAbonos2.Text = 0
            lblTotalCargos2.Text = 0

            For Each row As UltraGridRow In grdCompras.Rows
                lblTotalAbonos2.Text = (Math.Round(CDbl(row.Cells("Abonos").Value), 2) + Math.Round(CDbl(lblTotalAbonos2.Text), 2)).ToString("C")
                lblTotalCargos2.Text = (Math.Round(CDbl(row.Cells("CARGOS").Value), 2) + Math.Round(CDbl(lblTotalCargos2.Text), 2)).ToString("C")
                If row.Cells("Bandera").Value = 0 Then
                    contadorBanderas += 1
                End If
                If row.Cells("Bandera").Value = 2 Then
                    contadorBanderas2 += 1
                End If
            Next

            'CODIGO QUE ENVIA DATATABLE A PANTALLA DE VALENTIN
            If lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "Los totales en abonos y cargos no coinciden."
                btnEnvioContp.Enabled = False
                estamal = True
                objMesj.ShowDialog()
            End If


            If hsXMLDañados.Count > 0 Then
                If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "Se encontraron XML dañados, por favor reemplácelos y vuelva a consultar la información de la póliza.") Then
                    Dim objReemplazarXMLDañados As New ReemplazarXMLDañadosForm
                    objReemplazarXMLDañados.hsXMLDañados = hsXMLDañados
                    objReemplazarXMLDañados.StartPosition = FormStartPosition.CenterScreen
                    objReemplazarXMLDañados.ShowDialog()
                End If

                estamal = True
            ElseIf contadorBanderas > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas.ToString + " cleinte sin cuenta contable" + vbNewLine + " Favor de relacionarlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas.ToString + " clientes sin cuenta contable" + vbNewLine + " Favor de relacionarlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If contadorBanderas2 > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas2.ToString + " cleinte que no esta dado de alta en SAY" + vbNewLine + " Favor de crearlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas2.ToString + " clientes que no estan dados de alta en SAY" + vbNewLine + " Favor de crearlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If estamal = False Then
                bloquearControles(False)
            Else
                bloquearControles(True)
            End If
        Else
            advertencia.mensaje = "No hay información para mostrar"
            advertencia.ShowDialog()
        End If

    End Sub

    Public Sub llenarTablaVentasCanceladas()
        ultimafecha = "01-01-1900"
        estamal = False
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim tablaVentas As New DataTable
        Dim tablaCuentasGenerales As New DataTable
        Dim advertencia As New AdvertenciaForm
        Dim NOmbreCliente As String
        Dim cuentaVentasConIva As String = String.Empty
        Dim cuentaVentasDescConIva As String = String.Empty
        Dim cuentaVentasConIvaSAYID As String = ""

        Dim cuentaVentasSinIva As String = String.Empty
        Dim cuentaVentasDescSinIva As String = String.Empty
        Dim cuentaVentasSinIvaSAYID As String = ""

        Dim cuentaIVA As String = String.Empty
        Dim cuentaIVADesc As String = String.Empty
        Dim cuentaIVASayID As String = ""

        Dim color As New System.Drawing.Color
        color = Drawing.Color.White
        fechaDe = dtpDe.Text
        fechaA = dtpAl.Text

        'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(12-01-2016)
        tablaProveedores = objBu.validarclienteExisteSay2(empresaSAYContpaqSICY)

        primaryKey(0) = tablaProveedores.Columns(0)
        tablaProveedores.PrimaryKey = primaryKey

        tablaProv = objBu.cargarCuentaContableSayClienteNueva2(empresaSAYContpaqSICY)

        'BUSCA LA CUENTA GENERAL DE VENTAS CON/SIN IVA
        tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "VENTAS_CON_IVA", "", tipoPoliza1)
        If tablaCuentasGenerales.Rows.Count > 0 Then
            cuentaVentasConIva = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
            cuentaVentasDescConIva = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
            cuentaVentasConIvaSAYID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
        Else
            advertencia.mensaje = "Favor de dar de alta la cuenta de ventas para esta empresa."
            advertencia.ShowDialog()
            grdCompras.DataSource = Nothing
            btnEnvioContp.Enabled = False
            estamal = True
            Exit Sub
        End If

        'BUSCA LA CUENTA GENERAL DE IVA PENDIENTE DE COBRO
        tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_COBRO", "", tipoPoliza1)
        If tablaCuentasGenerales.Rows.Count > 0 Then
            cuentaIVA = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
            cuentaIVADesc = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
            cuentaIVASayID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
        Else
            advertencia.mensaje = "Favor de dar de alta la cuenta de IVA pendiente de cobro para esta empresa."
            advertencia.ShowDialog()
            grdCompras.DataSource = Nothing
            btnEnvioContp.Enabled = False
            estamal = True
            Exit Sub
        End If

        'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(12-01-2016)

        tablaVentas = objBu.CargaGridPolizaVentasCanceladas(estatus, doctoVentasID, fechaDe.Date, fechaA.Date, cmbEmpresa.SelectedValue)
        If tablaVentas.Rows.Count > 0 Then

            ''BUSCA LA CUENTA GENERAL DE VENTAS CON/SIN IVA
            'tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "VENTAS_CON_IVA", "")
            'If tablaCuentasGenerales.Rows.Count > 0 Then
            '    cuentaVentasConIva = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
            '    cuentaVentasDescConIva = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
            '    cuentaVentasConIvaSAYID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
            'Else
            '    advertencia.mensaje = "Favor de dar de alta la cuenta de ventas para esta empresa."
            '    advertencia.ShowDialog()
            '    grdCompras.DataSource = Nothing
            '    btnEnvioContp.Enabled = False
            '    estamal = True
            '    Exit Sub
            'End If

            ''BUSCA LA CUENTA GENERAL DE IVA PENDIENTE DE COBRO
            'tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_COBRO", "")
            'If tablaCuentasGenerales.Rows.Count > 0 Then
            '    cuentaIVA = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
            '    cuentaIVADesc = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
            '    cuentaIVASayID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
            'Else
            '    advertencia.mensaje = "Favor de dar de alta la cuenta de IVA pendiente de cobro para esta empresa."
            '    advertencia.ShowDialog()
            '    grdCompras.DataSource = Nothing
            '    btnEnvioContp.Enabled = False
            '    estamal = True
            '    Exit Sub
            'End If

            Dim listParametros As DataTable = tablaVentas.Clone
            grdCompras.DataSource = listParametros
            For Each row As DataRow In tablaVentas.Rows
                'BUSCAR UUID
                Dim polizaVentas As New Entidades.Polizas
                polizaVentas = extraerUUID(row.Item("rutaXML"))


                'AGREGA CARGO A LA CUENTA DE VENTAS
                'row.Item("Cargos")
                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                If row.Item("IVA") > 0 Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaVentasConIva
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = cuentaVentasDescConIva
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaVentasConIvaSAYID
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaVentasSinIva
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = cuentaVentasDescSinIva
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaVentasSinIvaSAYID
                End If

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = polizaVentas.Puuid
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = polizaVentas.Pserie
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = polizaVentas.Pfolio
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = row.Item("Referencia")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "0"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = "1"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaXML").Value = row.Item("rutaXML")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaPDF").Value = row.Item("rutaPDF")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteId").Value = row.Item("ClienteId")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdVenta").Value = row.Item("IdVenta")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SubTotal").Value = row.Item("SubTotal")


                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                End If


                'AGREGA ABONO A IVA PENDIENTE DE COBRO

                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = cuentaIVADesc
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaIVA
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = polizaVentas.Puuid
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = polizaVentas.Pserie
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = polizaVentas.Pfolio
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = row.Item("Referencia")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "0"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = "1"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaXML").Value = row.Item("rutaXML")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaPDF").Value = row.Item("rutaPDF")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteId").Value = row.Item("ClienteId")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdVenta").Value = row.Item("IdVenta")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVASayID
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SubTotal").Value = row.Item("SubTotal")
                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                End If


                If row.Item("FECHA") > ultimafecha Then
                    ultimafecha = row.Item("FECHA")
                End If


                'AGREGA CARGO A CUENTA DEL CLIENTE
                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("Abonos")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = polizaVentas.Puuid
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = polizaVentas.Pserie
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = polizaVentas.Pfolio
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = row.Item("Referencia")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "1"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaXML").Value = row.Item("rutaXML")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaPDF").Value = row.Item("rutaPDF")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteId").Value = row.Item("ClienteId")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdVenta").Value = row.Item("IdVenta")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SubTotal").Value = row.Item("SubTotal")

                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    color = Drawing.Color.LightSteelBlue
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    color = Drawing.Color.White
                End If
                'llenarCuentasClientes(row)
                llenarCuentasClientesOptimizado(row)

                If grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value <> "" Then
                    Dim obBUNombre As New Contabilidad.Negocios.AltaPolizaBU
                    Dim tablaNombre As New DataTable
                    tablaNombre = obBUNombre.obtenerNombreCuentaContpaq(grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value, servidorBD, empresaBD)
                    NOmbreCliente = tablaNombre.Rows(0).Item("Nombre")
                    grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("Concepto").Value = tablaNombre.Rows(0).Item("Nombre")
                    grdCompras.Rows(grdCompras.Rows.Count - 3).Cells("Concepto").Value = tablaNombre.Rows(0).Item("Nombre")
                End If


            Next

            Dim contadorBanderas As Integer = 0
            Dim contadorBanderas2 As Integer = 0
            lblTotalAbonos2.Text = 0
            lblTotalCargos2.Text = 0

            For Each row As UltraGridRow In grdCompras.Rows
                lblTotalAbonos2.Text = (Math.Round(CDbl(row.Cells("Abonos").Value), 2) + Math.Round(CDbl(lblTotalAbonos2.Text), 2)).ToString("C")
                lblTotalCargos2.Text = (Math.Round(CDbl(row.Cells("CARGOS").Value), 2) + Math.Round(CDbl(lblTotalCargos2.Text), 2)).ToString("C")
                If row.Cells("Bandera").Value = 0 Then
                    contadorBanderas += 1
                End If
                If row.Cells("Bandera").Value = 2 Then
                    contadorBanderas2 += 1
                End If
            Next

            'CODIGO QUE ENVIA DATATABLE A PANTALLA DE VALENTIN
            If lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "Los totales en abonos y cargos no coinciden."
                btnEnvioContp.Enabled = False
                estamal = True
                objMesj.ShowDialog()
            End If

            If contadorBanderas > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas.ToString + " cleinte sin cuenta contable" + vbNewLine + " Favor de relacionarlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas.ToString + " clientes sin cuenta contable" + vbNewLine + " Favor de relacionarlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If contadorBanderas2 > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas2.ToString + " cleinte que no esta dado de alta en SAY" + vbNewLine + " Favor de crearlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas2.ToString + " clientes que no estan dados de alta en SAY" + vbNewLine + " Favor de crearlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If hsXMLDañados.Count > 0 Then
                If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "Se encontraron XML dañados, por favor reemplácelos y vuelva a consultar la información de la póliza.") Then
                    Dim objReemplazarXMLDañados As New ReemplazarXMLDañadosForm
                    objReemplazarXMLDañados.hsXMLDañados = hsXMLDañados
                    objReemplazarXMLDañados.StartPosition = FormStartPosition.CenterScreen
                    objReemplazarXMLDañados.ShowDialog()
                End If

                estamal = True
            End If

            If estamal = False Then
                bloquearControles(False)
            Else
                bloquearControles(True)
            End If
        Else
            advertencia.mensaje = "No hay información para mostrar"
            advertencia.ShowDialog()
        End If

    End Sub

    Public Sub llenarTablaGastos()
        hsXMLDañados.Clear()
        ultimafecha = "01-01-1900"
        estamal = False
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim tablaGastos As New DataTable
        Dim tabla As New DataTable
        Dim tablaConsulta As New DataTable
        Dim cuentaIVA As String = ""
        Dim cuentaIVADesc As String = ""
        Dim cuentaIVASAYID As String = ""
        Dim cuentaMaterialSAYID As String = ""
        Dim rowRespaldo As DataRow = Nothing
        Dim contadorRows As Integer
        Dim color As Drawing.Color
        Dim concepto As String = ""
        Dim dtCuentasAF As DataTable
        'Dim dtCuentaMaterial As DataTable
        Dim renglon As DataRow
        'Dim proveedorRFC As String


        color = Drawing.Color.White

        'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-01-2016)

        tablaProveedores = objBu.obtieneProveedores(servidorBD, empresaBD)

        primaryKey(0) = tablaProveedores.Columns(0)
        tablaProveedores.PrimaryKey = primaryKey

        tablaProv = objBu.cargarCuentaContableSayProveedorNueva2(empresaSAYContpaqSICY)

        tabla = objBu.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_PAGO", "", tipoPoliza1)

        If tabla.Rows.Count > 0 Then

            cuentaIVA = tabla.Rows(0).Item("cgen_cuenta")
            cuentaIVADesc = tabla.Rows(0).Item("cgen_nombre")
            cuentaIVASAYID = tabla.Rows(0).Item("cuentaSAYID")
        Else
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
            objMesj.ShowDialog()
            estamal = True
            grdCompras.DataSource = Nothing
            btnEnvioContp.Enabled = False
            Exit Sub
        End If

        Dim tipoPoliza As String = "GASTOS', 'PRODUCTO TERMINADO','GASTOS DE TRANSPORTE', 'COMPRAS','ACTIVO FIJO"

        tablaConsulta = objBu.obtenerIdDescripcionCuentaGeneral2(empresaSAYContpaqSICY, tipoPoliza)
        primaryKey(0) = tablaConsulta.Columns(2)
        tablaConsulta.PrimaryKey = primaryKey

        'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-01-2016)

        If cmbTipo.Text = "PRODUCTO TERMINADO" Or cmbTipo.Text = "GASTOS DE TRANSPORTE" Then
            tablaGastos = objBu.cargarGridProductoTerminado(contribuyentesID, doctoVentasID, dtpDe.Value, dtpAl.Value, cmbEstatus.Text, cmbTipo.Text.ToString)
        Else
            tablaGastos = objBu.cargarGridComprasGastos(contribuyentesID, doctoVentasID, dtpDe.Value, dtpAl.Value, cmbEstatus.Text, cmbTipo.Text.ToString)
        End If

        dtCuentasAF = objBu.CuentasContables_ActivoFijo(cmbEmpresa.SelectedValue)
        'For Each row As DataRow In tablaGastos.Rows
        '    For Each fila As DataRow In dtCuentasAF.Rows
        '        If row.Item("") = fila.Item("") Then
        '            dtCuentaMaterial = 

        '            Exit For
        '        End If
        '    Next
        'Next


        Dim contador As Integer = 0
        Dim listParametros As DataTable = tablaGastos.Clone
        Dim listaEntidades As New Entidades.Polizas
        Dim cuentasGastosSinRelacionar As String = ""
        Dim mensajeAviso As New AvisoForm
        grdCompras.DataSource = listParametros


        If tablaGastos.Rows.Count > 0 Then
            contadorRows = tablaGastos.Rows.Count
            For Each row As DataRow In tablaGastos.Rows

                If contador = 0 Then
                    rowRespaldo = row
                End If

                If row.Item("Referencia") = rowRespaldo.Item("Referencia") And row.Item("CuentaMaterial") = rowRespaldo.Item("CuentaMaterial") And contador = 0 Then
                    contador = 0
                ElseIf row.Item("Referencia") = rowRespaldo.Item("Referencia") And row.Item("CuentaMaterial") = rowRespaldo.Item("CuentaMaterial") And contador = 3 Then
                    contador = 3
                ElseIf row.Item("Referencia") = rowRespaldo.Item("Referencia") Then
                    contador = 1
                ElseIf row.Item("Referencia") <> rowRespaldo.Item("Referencia") Then
                    contador = 2
                End If

                If contador = 0 Then
                    ''Agrega gastos   

                    'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-01-2016)
                    'tabla = objBu.obtenerIdDescripcionCuentaGeneral(row.Item("CuentaMaterial"), empresaSAYContpaqSICY)

                    'If tabla.Rows.Count > 0 Then
                    '    cuentaMaterialSAYID = tabla.Rows(0).Item("cuentaSAYID")
                    'Else
                    '    cuentaMaterialSAYID = 0
                    'End If

                    renglon = tablaConsulta.Rows.Find(row.Item("CuentaMaterial"))

                    If renglon Is Nothing Then
                        cuentaMaterialSAYID = 0
                    Else
                        cuentaMaterialSAYID = renglon.Item("cuentaSAYID")
                    End If

                    concepto = ""

                    'tabla = objBu.cargarCuentaContableSayProveedorNueva(empresaSAYContpaqSICY, row.Item("proveedorSicyID"))
                    'If tabla.Rows.Count > 0 Then
                    '    concepto = tabla.Rows(0).Item("Descripcion")
                    'End If

                    For Each row1 As DataRow In tablaProv.Rows
                        If row1.Item(3) = row.Item("proveedorSicyID") Then
                            renglon = row1
                            concepto = renglon.Item("Descripcion")
                            Exit For
                        End If
                    Next
                    'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-01-2016)


                    If cmbTipo.Text = "GASTOS Y COMPRAS" Then
                        For Each fila As DataRow In dtCuentasAF.Rows
                            If row.Item("CuentaMaterial") = fila.Item(2) Then
                                concepto = row.Item("Concepto")
                            End If
                        Next
                    End If

                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(row.Item("RutaXML"))

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = row.Item("descripcionCuenta")

                    If cmbTipo.Text = "PRODUCTO TERMINADO" Or cmbTipo.Text = "GASTOS DE TRANSPORTE" Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Subtotal")
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("cargos")
                    End If
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = concepto
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = row.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = row.Item("Subtotal")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = row.Item("TipoCompra")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = row.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = row.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = row.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaMaterialSAYID
                    '   rowRespaldo = row
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If

                    contador = 3

                    If IsDBNull(row.Item("DescripcionCuentaMaterial")) Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.Yellow
                        If cuentasGastosSinRelacionar.Contains(row.Item("CuentaMaterial").ToString) Then
                        Else
                            cuentasGastosSinRelacionar += row.Item("CuentaMaterial").ToString + ", "
                        End If
                    End If

                ElseIf contador = 3 Then
                    ''Agrega gastos         

                    If cmbTipo.Text = "PRODUCTO TERMINADO" Or cmbTipo.Text = "GASTOS DE TRANSPORTE" Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value + row.Item("Subtotal")
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value + row.Item("CARGOS")
                    End If

                    contador = 3
                    rowRespaldo = row
                ElseIf contador = 1 Then
                    ''Agrega gastos

                    'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-01-2016)
                    'tabla = objBu.obtenerIdDescripcionCuentaGeneral(row.Item("CuentaMaterial"), empresaSAYContpaqSICY)
                    'If tabla.Rows.Count > 0 Then
                    '    cuentaMaterialSAYID = tabla.Rows(0).Item("cuentaSAYID")
                    'Else
                    '    cuentaMaterialSAYID = 0
                    'End If

                    renglon = tablaConsulta.Rows.Find(row.Item("CuentaMaterial"))

                    If renglon Is Nothing Then
                        cuentaMaterialSAYID = 0
                    Else
                        cuentaMaterialSAYID = renglon.Item("cuentaSAYID")
                    End If

                    concepto = ""
                    'tabla = objBu.cargarCuentaContableSayProveedorNueva(empresaSAYContpaqSICY, row.Item("proveedorSicyID"))
                    'If tabla.Rows.Count > 0 Then
                    '    concepto = tabla.Rows(0).Item("Descripcion")
                    'End If

                    For Each row1 As DataRow In tablaProv.Rows
                        If row1.Item(3) = row.Item("proveedorSicyID") Then
                            renglon = row1
                            concepto = renglon.Item("Descripcion")
                            Exit For
                        End If
                    Next

                    'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-01-2016)
                    If cmbTipo.Text = "GASTOS Y COMPRAS" Then
                        For Each fila As DataRow In dtCuentasAF.Rows
                            If row.Item("CuentaMaterial") = fila.Item(2) Then
                                concepto = row.Item("Concepto")
                            End If
                        Next
                    End If
                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(row.Item("RutaXML"))


                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = row.Item("descripcionCuenta")
                    If cmbTipo.Text = "PRODUCTO TERMINADO" Or cmbTipo.Text = "GASTOS DE TRANSPORTE" Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Subtotal")
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                    End If

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = concepto
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = row.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = row.Item("Subtotal")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = row.Item("TipoCompra")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = row.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = row.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = row.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaMaterialSAYID
                    '   rowRespaldo = row
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If

                    If IsDBNull(row.Item("DescripcionCuentaMaterial")) Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.Yellow
                        If cuentasGastosSinRelacionar.Contains(row.Item("CuentaMaterial").ToString) Then
                        Else
                            cuentasGastosSinRelacionar += row.Item("CuentaMaterial").ToString + ", "
                        End If
                    End If



                    contador = 1
                    rowRespaldo = row

                ElseIf contador = 2 Then
                    ''AGREGA RENGLON IVA

                    'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-01-2016)
                    concepto = ""
                    'tabla = objBu.cargarCuentaContableSayProveedorNueva(empresaSAYContpaqSICY, rowRespaldo.Item("proveedorSicyID"))
                    'If tabla.Rows.Count > 0 Then
                    '    concepto = tabla.Rows(0).Item("Descripcion")
                    'End If

                    For Each row1 As DataRow In tablaProv.Rows
                        If row1.Item(3) = rowRespaldo.Item("proveedorSicyID") Then
                            renglon = row1
                            concepto = renglon.Item("Descripcion")
                            Exit For
                        End If
                    Next
                    'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-01-2016)

                    listaEntidades = New Entidades.Polizas

                    listaEntidades = extraerUUID(rowRespaldo.Item("RutaXML"))


                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaIVA
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = cuentaIVADesc
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = rowRespaldo.Item("IVA")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = concepto
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = rowRespaldo.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = rowRespaldo.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = rowRespaldo.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = rowRespaldo.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = rowRespaldo.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = rowRespaldo.Item("Subtotal")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = rowRespaldo.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = rowRespaldo.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = rowRespaldo.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = rowRespaldo.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = rowRespaldo.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = rowRespaldo.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = rowRespaldo.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVASAYID

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                    ''AGREGA PROVEEDOR
                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(rowRespaldo.Item("RutaXML"))
                    If cmbTipo.Text = "GASTOS Y COMPRAS" Then
                        If listaEntidades.PrutaXML <> "" Then
                            hsXMLDañados.Add(listaEntidades.PrutaXML + "|Proveedor|" + rowRespaldo.Item("Proveedor") + "|F-" + row.Item("Referencia"))
                        End If
                    End If

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = rowRespaldo.Item("Cuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = rowRespaldo.Item("Proveedor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = rowRespaldo.Item("Abonos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = rowRespaldo.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = rowRespaldo.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = rowRespaldo.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = rowRespaldo.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = rowRespaldo.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = rowRespaldo.Item("Subtotal")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = rowRespaldo.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = rowRespaldo.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = rowRespaldo.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = rowRespaldo.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = rowRespaldo.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = "P"
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = rowRespaldo.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = rowRespaldo.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = rowRespaldo.Item("descripcionCuenta")

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = rowRespaldo.Item("cuentaSAYID")

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                    llenarCuentasProveedoresOptimizado(rowRespaldo)

                    ''AGREGA  GASTO primer renglon del nuevo

                    'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-01-2016)
                    'tabla = objBu.obtenerIdDescripcionCuentaGeneral(row.Item("CuentaMaterial"), empresaSAYContpaqSICY)
                    'If tabla.Rows.Count > 0 Then
                    '    cuentaMaterialSAYID = tabla.Rows(0).Item("cuentaSAYID")
                    'Else
                    '    cuentaMaterialSAYID = 0
                    'End If


                    renglon = tablaConsulta.Rows.Find(row.Item("CuentaMaterial"))

                    If renglon Is Nothing Then
                        cuentaMaterialSAYID = 0
                    Else
                        cuentaMaterialSAYID = renglon.Item("cuentaSAYID")
                    End If

                    concepto = ""
                    'tabla = objBu.cargarCuentaContableSayProveedorNueva(empresaSAYContpaqSICY, row.Item("proveedorSicyID"))
                    'If tabla.Rows.Count > 0 Then
                    '    concepto = tabla.Rows(0).Item("Descripcion")
                    'End If

                    For Each row1 As DataRow In tablaProv.Rows
                        If row1.Item(3) = row.Item("proveedorSicyID") Then
                            renglon = row1
                            concepto = renglon.Item("Descripcion")
                            Exit For
                        End If
                    Next

                    'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-01-2016)

                    If cmbTipo.Text = "GASTOS Y COMPRAS" Then
                        For Each fila As DataRow In dtCuentasAF.Rows
                            If row.Item("CuentaMaterial") = fila.Item(2) Then
                                concepto = row.Item("Concepto")
                            End If
                        Next
                    End If
                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(row.Item("RutaXML"))

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = row.Item("descripcionCuenta")
                    If cmbTipo.Text = "PRODUCTO TERMINADO" Or cmbTipo.Text = "GASTOS DE TRANSPORTE" Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Subtotal")
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                    End If
                    ''grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Subtotal")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = concepto
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = row.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = row.Item("Subtotal")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = row.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = row.Item("TipoCompra")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = row.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = row.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = row.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaMaterialSAYID

                    If color = Drawing.Color.White Then
                        color = Drawing.Color.LightSteelBlue
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    Else
                        color = Drawing.Color.White
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    End If



                    If IsDBNull(row.Item("DescripcionCuentaMaterial")) Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.Yellow
                        If cuentasGastosSinRelacionar.Contains(row.Item("CuentaMaterial").ToString) Then
                        Else
                            cuentasGastosSinRelacionar += row.Item("CuentaMaterial").ToString + ", "
                        End If
                    End If
                    rowRespaldo = row
                    contador = 1

                    If grdCompras.Rows(0).Cells("CuentaSAYID").Value = 0 Then
                        grdCompras.Rows(0).Cells("CuentaSAYID").Appearance.BackColor = Drawing.Color.Purple

                    End If

                End If


                contadorRows -= 1
                If contadorRows = 0 Then
                    'PARA TERMINAR
                    ''AGREGA IVA
                    'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-01-2016)
                    concepto = ""
                    'tabla = objBu.cargarCuentaContableSayProveedorNueva(empresaSAYContpaqSICY, rowRespaldo.Item("proveedorSicyID"))
                    'If tabla.Rows.Count > 0 Then
                    '    concepto = tabla.Rows(0).Item("Descripcion")
                    'End If

                    For Each row1 As DataRow In tablaProv.Rows
                        If row1.Item(3) = rowRespaldo.Item("proveedorSicyID") Then
                            renglon = row1
                            concepto = renglon.Item("Descripcion")
                            Exit For
                        End If
                    Next
                    'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(09-01-2016)
                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(rowRespaldo.Item("RutaXML"))
                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaIVA
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = cuentaIVADesc
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = rowRespaldo.Item("IVA")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = concepto
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = rowRespaldo.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = rowRespaldo.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = rowRespaldo.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = rowRespaldo.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = rowRespaldo.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = rowRespaldo.Item("Subtotal")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = rowRespaldo.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = rowRespaldo.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = rowRespaldo.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = rowRespaldo.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = rowRespaldo.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = rowRespaldo.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = rowRespaldo.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = rowRespaldo.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVASAYID

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(rowRespaldo.Item("RutaXML"))
                    If cmbTipo.Text = "GASTOS Y COMPRAS" Then
                        If listaEntidades.PrutaXML <> "" Then
                            hsXMLDañados.Add(listaEntidades.PrutaXML + "|Cliente|" + rowRespaldo.Item("Proveedor") + "|F-" + row.Item("referencia"))
                        End If
                    End If

                    ''AGREGA PROVEEDOR

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = rowRespaldo.Item("Cuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = rowRespaldo.Item("Proveedor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("Abonos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = rowRespaldo.Item("Concepto")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = rowRespaldo.Item("Fecha")

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = rowRespaldo.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = rowRespaldo.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = rowRespaldo.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = rowRespaldo.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = rowRespaldo.Item("Subtotal")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = rowRespaldo.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = rowRespaldo.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = rowRespaldo.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = rowRespaldo.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = rowRespaldo.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = "P"
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = rowRespaldo.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = rowRespaldo.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = rowRespaldo.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = rowRespaldo.Item("cuentaSAYID")

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                    llenarCuentasProveedoresOptimizado(rowRespaldo)
                    If cuentasGastosSinRelacionar <> "" Then
                        btnEnvioContp.Enabled = False
                        mensajeAviso.mensaje = "Estas cuentas de materiales no tienen relación " + cuentasGastosSinRelacionar.ToString + " favor de crearlas en SAY para generar la póliza."
                        mensajeAviso.ShowDialog()
                    End If
                End If

                If row.Item("Fecha") > ultimafecha Then
                    ultimafecha = CDate(row.Item("Fecha"))
                End If
            Next

            Dim contadorBanderas As Integer = 0
            Dim contadorBanderas2 As Integer = 0
            lblTotalAbonos2.Text = 0
            lblTotalCargos2.Text = 0

            For Each row As UltraGridRow In grdCompras.Rows
                If row.Cells("CUENTA").Value = "" And row.Cells("PROVEEDOR").Value = "" And IsDBNull(row.Cells("CARGOS").Value) Then
                    Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No es posible realizar esta poliza debido a que la factura " + (row.Cells("REFERENCIA").Value).ToString + " del proveedor " + (row.Cells("CONCEPTO").Value).ToString + " se realizo sin una orden de compra.")
                Else
                    lblTotalAbonos2.Text = (Math.Round(CDbl(row.Cells("Abonos").Value), 2) + Math.Round(CDbl(lblTotalAbonos2.Text), 2)).ToString("C")
                    lblTotalCargos2.Text = (Math.Round(CDbl(row.Cells("CARGOS").Value), 2) + Math.Round(CDbl(lblTotalCargos2.Text), 2)).ToString("C")
                    If row.Cells("Bandera").Value = 0 Then
                        contadorBanderas += 1
                    End If
                    If row.Cells("Bandera").Value = 2 Then
                        contadorBanderas2 += 1
                    End If
                End If
            Next

            Dim tablaSinXML As New DataTable
            tablaSinXML = objBu.CargaComprasSinComprobante(dtpDe.Value, dtpAl.Value, doctoVentasID)

            If tablaSinXML.Rows.Count > 0 Then
                Dim confirmacion As New Tools.ConfirmarForm
                confirmacion.mensaje = "Se encontraron compras sin XML relacionado. ¿Desea ver la lista de documentos para cargar el XML?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim form As New RelacionComprobantesFiscalesForm
                    form.tipo_busqueda = 2
                    form.fechaInicio = dtpDe.Value
                    form.fechaFin = dtpAl.Value
                    form.empresaID = doctoVentasID
                    form.ShowDialog(Me)
                End If
            End If


            If hsXMLDañados.Count > 0 Then
                If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "Se encontraron XML dañados, por favor reemplácelos y vuelva a consultar la información de la póliza.") Then
                    Dim objReemplazarXMLDañados As New ReemplazarXMLDañadosForm
                    objReemplazarXMLDañados.hsXMLDañados = hsXMLDañados
                    objReemplazarXMLDañados.StartPosition = FormStartPosition.CenterScreen
                    objReemplazarXMLDañados.ShowDialog()
                End If

                estamal = True
            ElseIf lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "Los totales en abonos y cargos no coinciden."
                btnEnvioContp.Enabled = False
                estamal = True
                objMesj.ShowDialog()
            End If
            If estamal = False Then
                bloquearControles(False)
            Else
                bloquearControles(True)
            End If


            For Each row As UltraGridRow In grdCompras.Rows
                If Not IsDBNull(row.Cells("cuentaSAYID").Value) Then
                    If row.Cells("cuentaSAYID").Value = "" Then
                        'row.Appearance.BackColor = Drawing.Color.MediumPurple
                        'btnEnvioContp.Enabled = False
                    ElseIf row.Cells("cuentaSAYID").Value = 0 Then
                        row.Appearance.BackColor = Drawing.Color.MediumPurple
                        btnEnvioContp.Enabled = False
                    End If
                End If
            Next

        Else

            Dim tablaSinXML As New DataTable
            tablaSinXML = objBu.CargaComprasSinComprobante(dtpDe.Value, dtpAl.Value, doctoVentasID)

            If tablaSinXML.Rows.Count > 0 Then
                Dim confirmacion As New Tools.ConfirmarForm
                confirmacion.mensaje = "Se encontraron compras sin XML relacionado. ¿Desea ver la lista de documentos para cargar el XML?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim form As New RelacionComprobantesFiscalesForm
                    form.tipo_busqueda = 2
                    form.fechaInicio = dtpDe.Value
                    form.fechaFin = dtpAl.Value
                    form.empresaID = doctoVentasID
                    form.ShowDialog(Me)
                End If
            End If


            grdCompras.DataSource = Nothing
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "No hay información para mostrar"
            btnEnvioContp.Enabled = False
            bloquearControles(True)
            objMesj.ShowDialog()
        End If

    End Sub

    Public Sub llenarTablaActivoFijo()
        ultimafecha = "01-01-1900"
        estamal = False
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim dttablaActivoFijo, tablaConsulta As New DataTable
        Dim tabla As New DataTable
        Dim cuentaIVA As String = ""
        Dim cuentaIVADesc As String = ""
        Dim cuentaIVASAYID As String = ""
        Dim cuentaMaterialSAYID As String = ""
        Dim rowRespaldo As DataRow = Nothing
        Dim renglon As DataRow = Nothing
        Dim contadorRows As Integer
        Dim color As Drawing.Color
        Dim concepto As String = ""
        color = Drawing.Color.White

        'INICIO (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(12-01-2016)
        tablaProveedores = objBu.obtieneProveedores(servidorBD, empresaBD)

        primaryKey(0) = tablaProveedores.Columns(0)
        tablaProveedores.PrimaryKey = primaryKey

        tablaProv = objBu.cargarCuentaContableSayProveedorNueva2(empresaSAYContpaqSICY)

        tabla = objBu.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_PAGO", "", tipoPoliza1)
        If tabla.Rows.Count > 0 Then

            cuentaIVA = tabla.Rows(0).Item("cgen_cuenta")
            cuentaIVADesc = tabla.Rows(0).Item("cgen_nombre")
            cuentaIVASAYID = tabla.Rows(0).Item("cuentaSAYID")
        Else
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
            objMesj.ShowDialog()
            estamal = True
            grdCompras.DataSource = Nothing
            btnEnvioContp.Enabled = False
            Exit Sub
        End If

        tablaConsulta = objBu.obtenerIdDescripcionCuentaGeneral2(empresaSAYContpaqSICY, "ACTIVO FIJO")
        primaryKey(0) = tablaConsulta.Columns(2)
        tablaConsulta.PrimaryKey = primaryKey

        'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(12-01-2016)

        dttablaActivoFijo = objBu.cargarGridActivoFijo(contribuyentesID, dtpDe.Value, dtpAl.Value, doctoVentasID)

        Dim contador As Integer = 0
        Dim listParametros As DataTable = dttablaActivoFijo.Clone
        Dim listaEntidades As New Entidades.Polizas
        Dim cuentasGastosSinRelacionar As String = ""
        Dim mensajeAviso As New AvisoForm
        grdCompras.DataSource = listParametros

        'tabla = objBu.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_PAGO", "")
        'If tabla.Rows.Count > 0 Then

        '    cuentaIVA = tabla.Rows(0).Item("cgen_cuenta")
        '    cuentaIVADesc = tabla.Rows(0).Item("cgen_nombre")
        '    cuentaIVASAYID = tabla.Rows(0).Item("cuentaSAYID")
        'Else
        '    Dim objMesj As New Tools.AdvertenciaForm
        '    objMesj.mensaje = "Favor dar de alta las cuentas generales para este tipo de poliza y esta empresa."
        '    objMesj.ShowDialog()
        '    estamal = True
        '    grdCompras.DataSource = Nothing
        '    btnEnvioContp.Enabled = False
        '    Exit Sub
        'End If
        If dttablaActivoFijo.Rows.Count > 0 Then
            contadorRows = dttablaActivoFijo.Rows.Count
            For Each row As DataRow In dttablaActivoFijo.Rows

                If contador = 0 Then
                    rowRespaldo = row
                End If

                If row.Item("Referencia") = rowRespaldo.Item("Referencia") And row.Item("CuentaMaterial") = rowRespaldo.Item("CuentaMaterial") And contador = 0 Then
                    contador = 0
                ElseIf row.Item("Referencia") = rowRespaldo.Item("Referencia") And row.Item("CuentaMaterial") = rowRespaldo.Item("CuentaMaterial") And contador = 3 Then
                    contador = 3
                ElseIf row.Item("Referencia") = rowRespaldo.Item("Referencia") Then
                    contador = 1
                ElseIf row.Item("Referencia") <> rowRespaldo.Item("Referencia") Then
                    contador = 2
                End If

                If contador = 0 Then
                    ''Agrega gastos   
                    'tabla = objBu.obtenerIdDescripcionCuentaGeneral(row.Item("CuentaMaterial"), empresaSAYContpaqSICY)

                    'If tabla.Rows.Count > 0 Then
                    '    cuentaMaterialSAYID = tabla.Rows(0).Item("cuentaSAYID")
                    'Else
                    '    cuentaMaterialSAYID = 0
                    'End If

                    'concepto = ""

                    'tabla = objBu.cargarCuentaContableSayProveedorNueva(empresaSAYContpaqSICY, row.Item("proveedorSicyID"))
                    'If tabla.Rows.Count > 0 Then
                    '    concepto = tabla.Rows(0).Item("Descripcion")
                    'End If

                    renglon = tablaConsulta.Rows.Find(row.Item("CuentaMaterial"))

                    If renglon Is Nothing Then
                        cuentaMaterialSAYID = 0
                    Else
                        cuentaMaterialSAYID = renglon.Item("cuentaSAYID")
                    End If

                    concepto = ""

                    For Each row1 As DataRow In tablaProv.Rows
                        If row1.Item(3) = row.Item("proveedorSicyID") Then
                            renglon = row1
                            concepto = renglon.Item("Descripcion")
                            Exit For
                        End If
                    Next

                    'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(12-01-2016)

                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(row.Item("RutaXML"))

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = row.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("Concepto")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = row.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = CDbl(row.Item("Cargos"))
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = row.Item("TipoCompra")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = row.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = row.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = row.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaMaterialSAYID
                    '   rowRespaldo = row
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If

                    contador = 1

                    If IsDBNull(row.Item("DescripcionCuentaMaterial")) Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.Yellow
                        If cuentasGastosSinRelacionar.Contains(row.Item("CuentaMaterial").ToString) Then
                        Else
                            cuentasGastosSinRelacionar += row.Item("CuentaMaterial").ToString + ", "
                        End If
                    End If

                ElseIf contador = 3 Then
                    ''Agrega gastos         

                    grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("Cargos").Value = grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("Cargos").Value + row.Item("Subtotal")

                    contador = 3
                    rowRespaldo = row
                ElseIf contador = 1 Then
                    ''Agrega gastos          
                    'tabla = objBu.obtenerIdDescripcionCuentaGeneral(row.Item("CuentaMaterial"), empresaSAYContpaqSICY)
                    'If tabla.Rows.Count > 0 Then
                    '    cuentaMaterialSAYID = tabla.Rows(0).Item("cuentaSAYID")
                    'Else
                    '    cuentaMaterialSAYID = 0
                    'End If
                    'concepto = ""
                    'tabla = objBu.cargarCuentaContableSayProveedorNueva(empresaSAYContpaqSICY, row.Item("proveedorSicyID"))
                    'If tabla.Rows.Count > 0 Then
                    '    concepto = tabla.Rows(0).Item("Descripcion")
                    'End If

                    renglon = tablaConsulta.Rows.Find(row.Item("CuentaMaterial"))

                    If renglon Is Nothing Then
                        cuentaMaterialSAYID = 0
                    Else
                        cuentaMaterialSAYID = renglon.Item("cuentaSAYID")
                    End If

                    concepto = ""

                    For Each row1 As DataRow In tablaProv.Rows
                        If row1.Item(3) = row.Item("proveedorSicyID") Then
                            renglon = row1
                            concepto = renglon.Item("Descripcion")
                            Exit For
                        End If
                    Next

                    'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(12-01-2016)


                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(row.Item("RutaXML"))

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = row.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("Concepto")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = row.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = row.Item("cargos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = row.Item("TipoCompra")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = row.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = row.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = row.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaMaterialSAYID
                    '   rowRespaldo = row
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If

                    If IsDBNull(row.Item("DescripcionCuentaMaterial")) Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.Yellow
                        If cuentasGastosSinRelacionar.Contains(row.Item("CuentaMaterial").ToString) Then
                        Else
                            cuentasGastosSinRelacionar += row.Item("CuentaMaterial").ToString + ", "
                        End If
                    End If



                    contador = 1
                    rowRespaldo = row

                ElseIf contador = 2 Then
                    ''AGREGA RENGLON IVA
                    'concepto = ""
                    'tabla = objBu.cargarCuentaContableSayProveedorNueva(empresaSAYContpaqSICY, rowRespaldo.Item("proveedorSicyID"))
                    'If tabla.Rows.Count > 0 Then
                    '    concepto = tabla.Rows(0).Item("Descripcion")
                    'End If

                    concepto = ""

                    For Each row1 As DataRow In tablaProv.Rows
                        If row1.Item(3) = rowRespaldo.Item("proveedorSicyID") Then
                            renglon = row1
                            concepto = renglon.Item("Descripcion")
                            Exit For
                        End If
                    Next

                    'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(12-01-2016)

                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(rowRespaldo.Item("RutaXML"))

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaIVA
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = cuentaIVADesc
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = rowRespaldo.Item("IVA")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = concepto
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = rowRespaldo.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = rowRespaldo.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = rowRespaldo.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = rowRespaldo.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = rowRespaldo.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = rowRespaldo.Item("IVA")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = rowRespaldo.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = rowRespaldo.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = rowRespaldo.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = rowRespaldo.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = rowRespaldo.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = rowRespaldo.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = rowRespaldo.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVASAYID

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                    ''AGREGA PROVEEDOR
                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(rowRespaldo.Item("RutaXML"))

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = rowRespaldo.Item("Cuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = rowRespaldo.Item("Proveedor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = rowRespaldo.Item("Abonos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = rowRespaldo.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = rowRespaldo.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = rowRespaldo.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = rowRespaldo.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = rowRespaldo.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = rowRespaldo.Item("Cargos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = rowRespaldo.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = rowRespaldo.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = rowRespaldo.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = rowRespaldo.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = rowRespaldo.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = "P"
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = rowRespaldo.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = rowRespaldo.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = rowRespaldo.Item("descripcionCuenta")

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = rowRespaldo.Item("cuentaSAYID")

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                    'llenarCuentasProveedores(rowRespaldo)
                    llenarCuentasProveedoresOptimizado(rowRespaldo)

                    ''AGREGA  GASTO primer renglon del nuevo
                    'tabla = objBu.obtenerIdDescripcionCuentaGeneral(row.Item("CuentaMaterial"), empresaSAYContpaqSICY)
                    'If tabla.Rows.Count > 0 Then
                    '    cuentaMaterialSAYID = tabla.Rows(0).Item("cuentaSAYID")
                    'Else
                    '    cuentaMaterialSAYID = 0
                    'End If

                    'concepto = ""
                    'tabla = objBu.cargarCuentaContableSayProveedorNueva(empresaSAYContpaqSICY, row.Item("proveedorSicyID"))
                    'If tabla.Rows.Count > 0 Then
                    '    concepto = tabla.Rows(0).Item("Descripcion")
                    'End If

                    renglon = tablaConsulta.Rows.Find(row.Item("CuentaMaterial"))

                    If renglon Is Nothing Then
                        cuentaMaterialSAYID = 0
                    Else
                        cuentaMaterialSAYID = renglon.Item("cuentaSAYID")
                    End If

                    concepto = ""

                    For Each row1 As DataRow In tablaProv.Rows
                        If row1.Item(3) = row.Item("proveedorSicyID") Then
                            renglon = row1
                            concepto = renglon.Item("Descripcion")
                            Exit For
                        End If
                    Next

                    'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(12-01-2016)

                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(row.Item("RutaXML"))

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = row.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("Concepto")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = row.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = row.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = row.Item("cargos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = row.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = row.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = row.Item("TipoCompra")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = row.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = row.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = row.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaMaterialSAYID

                    If color = Drawing.Color.White Then
                        color = Drawing.Color.LightSteelBlue
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    Else
                        color = Drawing.Color.White
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    End If



                    If IsDBNull(row.Item("DescripcionCuentaMaterial")) Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.Yellow
                        If cuentasGastosSinRelacionar.Contains(row.Item("CuentaMaterial").ToString) Then
                        Else
                            cuentasGastosSinRelacionar += row.Item("CuentaMaterial").ToString + ", "
                        End If
                    End If
                    rowRespaldo = row
                    contador = 1

                    If grdCompras.Rows(0).Cells("CuentaSAYID").Value = 0 Then
                        grdCompras.Rows(0).Cells("CuentaSAYID").Appearance.BackColor = Drawing.Color.Purple

                    End If

                End If


                contadorRows -= 1
                If contadorRows = 0 Then
                    'PARA TERMINAR
                    ''AGREGA IVA
                    'concepto = ""
                    'tabla = objBu.cargarCuentaContableSayProveedorNueva(empresaSAYContpaqSICY, rowRespaldo.Item("proveedorSicyID"))
                    'If tabla.Rows.Count > 0 Then
                    '    concepto = tabla.Rows(0).Item("Descripcion")
                    'End If

                    concepto = ""

                    For Each row1 As DataRow In tablaProv.Rows
                        If row1.Item(3) = rowRespaldo.Item("proveedorSicyID") Then
                            renglon = row1
                            concepto = renglon.Item("Descripcion")
                            Exit For
                        End If
                    Next

                    'FIN (YAZMIN ROCHA)(MODIFICACION DE LUGAR DE CONSULTAS)(12-01-2016)

                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(rowRespaldo.Item("RutaXML"))

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaIVA
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = cuentaIVADesc
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = rowRespaldo.Item("IVA")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = concepto
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = rowRespaldo.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = rowRespaldo.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = rowRespaldo.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = rowRespaldo.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = rowRespaldo.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = rowRespaldo.Item("IVA")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = rowRespaldo.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = rowRespaldo.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = rowRespaldo.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = rowRespaldo.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = rowRespaldo.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = rowRespaldo.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = rowRespaldo.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = rowRespaldo.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVASAYID

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                    listaEntidades = New Entidades.Polizas
                    listaEntidades = extraerUUID(rowRespaldo.Item("RutaXML"))

                    ''AGREGA PROVEEDOR
                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = rowRespaldo.Item("Cuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Proveedor").Value = rowRespaldo.Item("Proveedor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("Abonos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = rowRespaldo.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "F-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = rowRespaldo.Item("PolizaSAYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = rowRespaldo.Item("PolizaContpaqID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nave").Value = rowRespaldo.Item("Nave")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("proveedorSicyID").Value = rowRespaldo.Item("proveedorSicyID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = rowRespaldo.Item("Cargos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = rowRespaldo.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = rowRespaldo.Item("RutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = rowRespaldo.Item("RutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("compraSICYID").Value = rowRespaldo.Item("compraSICYID")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = rowRespaldo.Item("RespaldoColor")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoCompra").Value = "P"
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaMaterial").Value = rowRespaldo.Item("CuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuentaMaterial").Value = rowRespaldo.Item("DescripcionCuentaMaterial")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = rowRespaldo.Item("descripcionCuenta")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = rowRespaldo.Item("cuentaSAYID")

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If
                    'llenarCuentasProveedores(rowRespaldo)
                    llenarCuentasProveedoresOptimizado(rowRespaldo)
                    If cuentasGastosSinRelacionar <> "" Then
                        btnEnvioContp.Enabled = False
                        mensajeAviso.mensaje = "Estas cuentas de materiales no tienen relación " + cuentasGastosSinRelacionar.ToString + " favor de crearlas en SAY para generar la póliza."
                        mensajeAviso.ShowDialog()
                    End If
                End If

                If row.Item("Fecha") > ultimafecha Then
                    ultimafecha = CDate(row.Item("Fecha"))
                End If


            Next

            ''grdCompras.DisplayLayout.Bands(0).AddNew()

            Dim contadorBanderas As Integer = 0
            Dim contadorBanderas2 As Integer = 0
            lblTotalAbonos2.Text = 0
            lblTotalCargos2.Text = 0

            For Each row As UltraGridRow In grdCompras.Rows
                lblTotalAbonos2.Text = (Math.Round(CDbl(row.Cells("Abonos").Value), 2) + Math.Round(CDbl(lblTotalAbonos2.Text), 2)).ToString("C")
                lblTotalCargos2.Text = (Math.Round(CDbl(row.Cells("CARGOS").Value), 2) + Math.Round(CDbl(lblTotalCargos2.Text), 2)).ToString("C")
                If row.Cells("Bandera").Value = 0 Then
                    contadorBanderas += 1
                End If
                If row.Cells("Bandera").Value = 2 Then
                    contadorBanderas2 += 1
                End If

            Next



            If lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "Los totales en abonos y cargos no coinciden."
                btnEnvioContp.Enabled = False
                estamal = True
                objMesj.ShowDialog()
            End If
            If estamal = False Then
                bloquearControles(False)
            Else
                bloquearControles(True)
            End If


            For Each row As UltraGridRow In grdCompras.Rows
                If Not IsDBNull(row.Cells("cuentaSAYID").Value) Then
                    If row.Cells("cuentaSAYID").Value = "" Then
                        'row.Appearance.BackColor = Drawing.Color.MediumPurple
                        'btnEnvioContp.Enabled = False
                    ElseIf row.Cells("cuentaSAYID").Value = 0 Then
                        row.Appearance.BackColor = Drawing.Color.MediumPurple
                        btnEnvioContp.Enabled = False
                    End If
                End If
            Next

        Else
            grdCompras.DataSource = Nothing
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "No hay información para mostrar"
            btnEnvioContp.Enabled = False
            bloquearControles(True)
            objMesj.ShowDialog()
        End If


        For Each row As UltraGridRow In grdCompras.Rows
            If IsNothing(grdCompras.DataSource) Then
                grdCompras.DataSource = Nothing
            End If
        Next

    End Sub

    Public Sub llenarTablaNotas_De_Credito()
        ultimafecha = "01-01-1900"
        estamal = False
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim tablaNotasCredito As New DataTable
        Dim tablaCuentasGenerales As New DataTable
        Dim advertencia As New AdvertenciaForm

        Dim cuentaVentasConIva As String = String.Empty
        Dim cuentaVentasDescConIva As String = String.Empty
        Dim cuentaVentasConIvaSAYID As String = ""

        Dim cuentaVentasSinIva As String = String.Empty
        Dim cuentaVentasDescSinIva As String = String.Empty
        Dim cuentaVentasSinIvaSAYID As String = ""

        Dim cuentaIVA As String = String.Empty
        Dim cuentaIVADesc As String = String.Empty
        Dim cuentaIVASayID As String = ""

        Dim contadorRows As Integer
        Dim contador As Integer = 0
        Dim rowRespaldo As DataRow = Nothing
        Dim concepto As String = String.Empty
        Dim tabla As DataTable
        Dim listaEntidades As Entidades.Polizas
        Dim cuentasNotasCreditoSinRelacionar As String = ""
        Dim mensajeAviso As New AvisoForm

        Dim color As New System.Drawing.Color
        color = Drawing.Color.White
        fechaDe = dtpDe.Text
        fechaA = dtpAl.Text

        Dim cuentaConceptoCobranzaSAYID As Integer

        tablaNotasCredito = objBu.CargaGridPolizaNotasDeCredito(doctoVentasID, fechaDe.Date, fechaA.Date, cmbEmpresa.SelectedValue)
        If tablaNotasCredito.Rows.Count > 0 Then
            contadorRows = tablaNotasCredito.Rows.Count

            'BUSCA LA CUENTA GENERAL DE IVA PENDIENTE DE COBRO
            tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_COBRO", "", tipoPoliza1)
            If tablaCuentasGenerales.Rows.Count > 0 Then
                cuentaIVA = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
                cuentaIVADesc = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
                cuentaIVASayID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
            Else
                advertencia.mensaje = "Favor de dar de alta la cuenta de IVA pendiente de cobro para esta empresa."
                advertencia.ShowDialog()
                grdCompras.DataSource = Nothing
                btnEnvioContp.Enabled = False
                estamal = True
                Exit Sub
            End If

            Dim listParametros As DataTable = tablaNotasCredito.Clone
            grdCompras.DataSource = listParametros


            For Each row As DataRow In tablaNotasCredito.Rows

                If contador = 0 Then
                    rowRespaldo = row
                End If
                If row.Item("rutaXML") <> "" Then




                    If row.Item("Referencia") = rowRespaldo.Item("Referencia") And row.Item("TipoMovimiento") = 0 Then
                        contador = 1
                    ElseIf row.Item("Referencia") = rowRespaldo.Item("Referencia") And row.Item("TipoMovimiento") = 1 And contador = 1 Then
                        contador = 2
                    ElseIf row.Item("Referencia") = rowRespaldo.Item("Referencia") And row.Item("TipoMovimiento") = 1 And contador > 1 Then
                        contador = 3
                    ElseIf row.Item("Referencia") <> rowRespaldo.Item("Referencia") And row.Item("TipoMovimiento") = 0 Then
                        contador = 1
                        If color = Drawing.Color.White Then
                            color = Drawing.Color.LightSteelBlue
                        Else
                            color = Drawing.Color.White
                        End If

                    End If

                    If contador = 1 Then
                        tabla = objBu.obtenerIdDescripcionCuentaGeneral(row.Item("CuentaNotaCredito"), empresaSAYContpaqSICY)
                        If tabla.Rows.Count > 0 Then
                            cuentaConceptoCobranzaSAYID = tabla.Rows(0).Item("cuentaSAYID")
                        Else
                            cuentaConceptoCobranzaSAYID = 0
                        End If

                        tabla = objBu.cargarCuentaContableSayClienteNueva(empresaSAYContpaqSICY, row.Item("ClienteId"))

                        If tabla.Rows.Count > 0 Then
                            concepto = tabla.Rows(0).Item("Descripcion")
                        End If
                        listaEntidades = New Entidades.Polizas
                        listaEntidades = extraerUUID(row.Item("RutaXML"))

                        grdCompras.DisplayLayout.Bands(0).AddNew()

                        ''===================================================================================================
                        ''----------------------------AGREGAMOS EL CARGO DE LA NOTA DE CREDITO------------------------------
                        ''===================================================================================================
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("CuentaNotaCredito")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TOTAL").Value = row.Item("TOTAL")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteID").Value = row.Item("ClienteId")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = 0
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la Cuenta").Value = row.Item("DescripcionCuenta")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = concepto
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "NCR-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = CDbl(row.Item("Subtotal"))
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdNotaCredito").Value = row.Item("IdNotaCredito")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "0"
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaNotaCredito").Value = row.Item("CuentaNotaCredito")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuenta").Value = row.Item("DescripcionCuenta")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaConceptoCobranzaSAYID

                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color

                        If color = Drawing.Color.White Then
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                        Else
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                        End If

                        contador = 1

                        If cuentaConceptoCobranzaSAYID = 0 Then
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.Purple
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 2

                            If cuentasNotasCreditoSinRelacionar.Contains(row.Item("CuentaNotaCredito").ToString) Then
                            Else
                                cuentasNotasCreditoSinRelacionar += row.Item("CuentaNotaCredito").ToString + ", "
                            End If
                        End If

                        rowRespaldo = row
                        contador = 1

                    ElseIf contador = 2 Then
                        If row.Item("TipoCliente") = "NACIONAL" Then
                            ''===================================================================================================
                            ''------------------------------------------AGREGA  IVA-------------------------------------------
                            ''===================================================================================================
                            tabla = objBu.cargarCuentaContableSayClienteNueva(empresaSAYContpaqSICY, rowRespaldo.Item("ClienteID"))

                            If tabla.Rows.Count > 0 Then
                                concepto = tabla.Rows(0).Item("Descripcion")
                            End If

                            listaEntidades = New Entidades.Polizas
                            listaEntidades = extraerUUID(row.Item("RutaXML"))

                            grdCompras.DisplayLayout.Bands(0).AddNew()
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TOTAL").Value = row.Item("TOTAL")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaIVA
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteID").Value = row.Item("ClienteID")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("IVA")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = 0
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = cuentaIVADesc
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = concepto
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "NCR-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = row.Item("IVA")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdNotaCredito").Value = row.Item("IdNotaCredito")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "0"
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = row.Item("RespaldoColor")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentanotacredito").Value = row.Item("cuentanotacredito")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = row.Item("descripcionCuenta")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVASayID
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color

                            If color = Drawing.Color.White Then
                                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                            Else
                                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                            End If

                        End If
                        ''===================================================================================================
                        ''--------------------------------------------AGREGA CLIENTE---------------------------------------
                        ''===================================================================================================
                        listaEntidades = New Entidades.Polizas
                        listaEntidades = extraerUUID(row.Item("RutaXML"))

                        grdCompras.DisplayLayout.Bands(0).AddNew()
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TOTAL").Value = row.Item("TOTAL")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("Cuenta")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteID").Value = row.Item("ClienteID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("Abonos")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la Cuenta").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("FACTURA")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "NCR-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = CDbl(row.Item("SUBTOTAL"))
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdNotaCredito").Value = row.Item("IdNotaCredito")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "P"
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = row.Item("RespaldoColor")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaNotaCredito").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuenta").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = row.Item("cuentaSAYID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color

                        If color = Drawing.Color.White Then
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                        Else
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                        End If

                        llenarCuentasClientes(row)

                        rowRespaldo = row

                    ElseIf contador = 3 Then

                        ''===================================================================================================
                        ''--------------------------------------------AGREGA CLIENTE---------------------------------------
                        ''===================================================================================================
                        listaEntidades = New Entidades.Polizas
                        listaEntidades = extraerUUID(row.Item("RutaXML"))

                        grdCompras.DisplayLayout.Bands(0).AddNew()
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TOTAL").Value = row.Item("TOTAL")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("Cuenta")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteID").Value = row.Item("ClienteID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("Abonos")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la Cuenta").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("FACTURA")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "NCR-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = CDbl(row.Item("SUBTOTAL"))
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdNotaCredito").Value = row.Item("IdNotaCredito")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "1"
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = row.Item("RespaldoColor")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaNotaCredito").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuenta").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = row.Item("cuentaSAYID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color

                        If color = Drawing.Color.White Then
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                        Else
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                        End If

                        llenarCuentasClientes(row)

                        rowRespaldo = row

                    End If
                    contadorRows -= 1
                    If row.Item("Fecha") > ultimafecha Then
                        ultimafecha = CDate(row.Item("Fecha"))
                    End If
                End If
            Next

        Dim contadorBanderas As Integer = 0
        Dim contadorBanderas2 As Integer = 0
        lblTotalAbonos2.Text = 0
        lblTotalCargos2.Text = 0

            Dim TotalCargos_NotaCredito, TotalAbonos_NotaCredito As Double
            'Dim TotalCargos_General, TotalAbonos_General As Double
        Dim diferencia As Double

        TotalCargos_NotaCredito = 0
        TotalAbonos_NotaCredito = 0

        Dim hsNotasCredito As New HashSet(Of String)
        For Each row As UltraGridRow In grdCompras.Rows
            hsNotasCredito.Add(row.Cells("Referencia").Value)
        Next

        For Each item In hsNotasCredito
            diferencia = 0
            TotalCargos_NotaCredito = 0
            TotalAbonos_NotaCredito = 0

            Dim Total As Double
            Dim rowIndexCargo As Integer = 0
            Dim rowIndexAbono As Integer = 0
            Dim IndiceCargoAsignado As Boolean = False

            For Each row As UltraGridRow In grdCompras.Rows
                If row.Cells("Referencia").Value = item Then
                    If row.Cells("TipoMovimiento").Value = "0" Then
                        If row.Cells("Nombre de la Cuenta").Text = "IVA Pendiente de Cobro" Then
                            rowIndexCargo = row.Index
                        End If

                        Dim CargoActual As String = row.Cells("Cargos").Text
                        TotalCargos_NotaCredito = Math.Round((TotalCargos_NotaCredito + CDbl(CargoActual)), 2)
                    ElseIf row.Cells("TipoMovimiento").Value = "P" Then
                        Total = Math.Round(CDbl(row.Cells("Total").Value), 2)
                        rowIndexAbono = row.Index
                        TotalAbonos_NotaCredito = Math.Round((TotalAbonos_NotaCredito + CDbl(row.Cells("ABONOS").Value)), 2)
                    ElseIf row.Cells("TipoMovimiento").Value = "1" Then
                        TotalAbonos_NotaCredito = Math.Round((TotalAbonos_NotaCredito + CDbl(row.Cells("ABONOS").Value)), 2)
                    End If
                End If
            Next


            If TotalAbonos_NotaCredito = TotalCargos_NotaCredito Then
                If Total < TotalAbonos_NotaCredito Then
                    diferencia = Math.Round((TotalCargos_NotaCredito - Total), 2)

                    If diferencia < 1.0 Then
                        grdCompras.Rows(rowIndexCargo - 1).Cells("cargos").Value = CDbl(grdCompras.Rows(rowIndexCargo - 1).Cells("cargos").Value) - diferencia
                        grdCompras.Rows(rowIndexAbono).Cells("abonos").Value = CDbl(grdCompras.Rows(rowIndexAbono).Cells("abonos").Value) - diferencia
                    End If
                End If
            ElseIf TotalAbonos_NotaCredito > TotalCargos_NotaCredito Then
                diferencia = Math.Round((TotalAbonos_NotaCredito - TotalCargos_NotaCredito), 2)

                If diferencia < 1.0 Then
                    If Total = TotalAbonos_NotaCredito Then
                        grdCompras.Rows(rowIndexCargo - 1).Cells("cargos").Value = CDbl(grdCompras.Rows(rowIndexCargo - 1).Cells("cargos").Value) + diferencia
                    Else
                        grdCompras.Rows(rowIndexAbono).Cells("abonos").Value = CDbl(grdCompras.Rows(rowIndexAbono).Cells("abonos").Value) - diferencia
                    End If
                End If
            ElseIf TotalCargos_NotaCredito > TotalAbonos_NotaCredito Then
                diferencia = Math.Round((TotalCargos_NotaCredito - TotalAbonos_NotaCredito), 2)

                If diferencia < 1.0 Then
                    If Total = TotalAbonos_NotaCredito Then
                        grdCompras.Rows(rowIndexCargo - 1).Cells("cargos").Value = CDbl(grdCompras.Rows(rowIndexCargo - 1).Cells("cargos").Value) - diferencia
                    Else
                        grdCompras.Rows(rowIndexAbono).Cells("abonos").Value = CDbl(grdCompras.Rows(rowIndexAbono).Cells("abonos").Value) + diferencia
                    End If
                End If
            End If

        Next

        TotalCargos_NotaCredito = 0
        TotalAbonos_NotaCredito = 0

        For Each row As UltraGridRow In grdCompras.Rows
            If row.Cells("Bandera").Value = 0 Then
                contadorBanderas += 1
            End If
            If row.Cells("Bandera").Value = 2 Then
                contadorBanderas2 += 1
            End If

            If row.Cells("TipoMovimiento").Value = "0" Then
                Dim CargoActual As String = row.Cells("Cargos").Value
                TotalCargos_NotaCredito = Math.Round((TotalCargos_NotaCredito + CDbl(CargoActual)), 2)
            ElseIf row.Cells("TipoMovimiento").Value = "P" Then
                TotalAbonos_NotaCredito = Math.Round((TotalAbonos_NotaCredito + CDbl(row.Cells("ABONOS").Value)), 2)
            ElseIf row.Cells("TipoMovimiento").Value = "1" Then
                TotalAbonos_NotaCredito = Math.Round((TotalAbonos_NotaCredito + CDbl(row.Cells("ABONOS").Value)), 2)
            End If
            lblTotalAbonos2.Text = TotalCargos_NotaCredito
            lblTotalCargos2.Text = TotalAbonos_NotaCredito

        Next

        'CODIGO QUE ENVIA DATATABLE A PANTALLA DE VALENTIN
        If lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Los totales en abonos y cargos no coinciden."
            btnEnvioContp.Enabled = False
            estamal = True
            objMesj.ShowDialog()
        End If

        If contadorBanderas > 0 Then
            btnEnvioContp.Enabled = False
            estamal = True
            Dim objMesj As New Tools.AdvertenciaForm
            If contadorBanderas = 1 Then
                objMesj.mensaje = "Existe " + contadorBanderas.ToString + " cleinte sin cuenta contable" + vbNewLine + " Favor de relacionarlo para poder generar la poliza.  "
            Else
                objMesj.mensaje = "Existen " + contadorBanderas.ToString + " clientes sin cuenta contable" + vbNewLine + " Favor de relacionarlos para poder generar la poliza.  "
            End If
            objMesj.ShowDialog()
        End If

        If contadorBanderas2 > 0 Then
            btnEnvioContp.Enabled = False
            estamal = True
            Dim objMesj As New Tools.AdvertenciaForm
            If contadorBanderas = 1 Then
                objMesj.mensaje = "Existe " + contadorBanderas2.ToString + " cleinte que no esta dado de alta en SAY" + vbNewLine + " Favor de crearlo para poder generar la poliza.  "
            Else
                objMesj.mensaje = "Existen " + contadorBanderas2.ToString + " clientes que no estan dados de alta en SAY" + vbNewLine + " Favor de crearlos para poder generar la poliza.  "
            End If
            objMesj.ShowDialog()
        End If

        If estamal = False Then
            bloquearControles(False)
        Else
            bloquearControles(True)
        End If
        Else
        advertencia.mensaje = "No hay información para mostrar"
        advertencia.ShowDialog()
        End If

    End Sub

    Public Sub llenarTablaNotas_De_Credito_Canceladas()
        ultimafecha = "01-01-1900"
        estamal = False
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim tablaNotasCreditoCanceladas As New DataTable
        Dim tablaCuentasGenerales As New DataTable
        Dim advertencia As New AdvertenciaForm

        Dim cuentaVentasConIva As String = String.Empty
        Dim cuentaVentasDescConIva As String = String.Empty
        Dim cuentaVentasConIvaSAYID As String = ""

        Dim cuentaVentasSinIva As String = String.Empty
        Dim cuentaVentasDescSinIva As String = String.Empty
        Dim cuentaVentasSinIvaSAYID As String = ""

        Dim cuentaIVA As String = String.Empty
        Dim cuentaIVADesc As String = String.Empty
        Dim cuentaIVASayID As String = ""

        Dim contadorRows As Integer = 0
        Dim contador As Integer = 0
        Dim rowRespaldo As DataRow = Nothing
        Dim concepto As String = String.Empty
        Dim tabla As DataTable
        Dim listaEntidades As Entidades.Polizas
        Dim cuentasNotasCreditoSinRelacionar As String = ""
        Dim mensajeAviso As New AvisoForm

        Dim color As New System.Drawing.Color
        color = Drawing.Color.White
        fechaDe = dtpDe.Text
        fechaA = dtpAl.Text

        Dim cuentaConceptoCobranzaSAYID As Integer

        tablaNotasCreditoCanceladas = objBu.CargaGridPolizaNotasDeCredito_Canceladas(doctoVentasID, fechaDe.Date, fechaA.Date, cmbEmpresa.SelectedValue)
        If tablaNotasCreditoCanceladas.Rows.Count > 0 Then
            contadorRows = tablaNotasCreditoCanceladas.Rows.Count

            'BUSCA LA CUENTA GENERAL DE IVA PENDIENTE DE COBRO
            tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_COBRO", "", tipoPoliza1)
            If tablaCuentasGenerales.Rows.Count > 0 Then
                cuentaIVA = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
                cuentaIVADesc = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
                cuentaIVASayID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
            Else
                advertencia.mensaje = "Favor de dar de alta la cuenta de IVA pendiente de cobro para esta empresa."
                advertencia.ShowDialog()
                grdCompras.DataSource = Nothing
                btnEnvioContp.Enabled = False
                estamal = True
                Exit Sub
            End If

            Dim listParametros As DataTable = tablaNotasCreditoCanceladas.Clone
            grdCompras.DataSource = listParametros


            For Each row As DataRow In tablaNotasCreditoCanceladas.Rows

                If contador = 0 Then
                    rowRespaldo = row
                End If
                If row.Item("rutaXML") <> "" Then

                    If row.Item("Referencia") = rowRespaldo.Item("Referencia") And row.Item("TipoMovimiento") = 0 Then
                        ''CARGOS
                        contador = 1
                    ElseIf row.Item("Referencia") = rowRespaldo.Item("Referencia") And row.Item("TipoMovimiento") = 1 Then
                        ''PRIMER ABONO
                        contador = 2
                    ElseIf (row.Item("Referencia") <> rowRespaldo.Item("Referencia") And row.Item("TipoMovimiento")) = 0 Then
                        ''IVA Y PRIMER CARGO EN CASO DE HABER MAS NOAS DE CREDITO,
                        contador = 3

                        If color = Drawing.Color.White Then
                            color = Drawing.Color.LightSteelBlue
                        Else
                            color = Drawing.Color.White
                        End If

                    End If

                    If contador = 1 Then

                        ''===================================================================================================
                        ''--------------------------------------------AGREGA CLIENTE--CARGO--------------------------------
                        ''===================================================================================================
                        listaEntidades = New Entidades.Polizas
                        listaEntidades = extraerUUID(row.Item("RutaXML"))

                        grdCompras.DisplayLayout.Bands(0).AddNew()
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TOTAL").Value = row.Item("TOTAL")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("Cuenta")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteID").Value = row.Item("ClienteID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la Cuenta").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("FACTURA")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "NCR-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = CDbl(row.Item("SUBTOTAL"))
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdNotaCredito").Value = row.Item("IdNotaCredito")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "0"
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = row.Item("RespaldoColor")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaNotaCredito").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuenta").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = row.Item("cuentaSAYID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color

                        If color = Drawing.Color.White Then
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                        Else
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                        End If

                        llenarCuentasClientes(row)

                        rowRespaldo = row



                    ElseIf contador = 2 Then

                        ''===================================================================================================
                        ''--------------------------------------------AGREGA MOTIVO--ABONO--------------------------------
                        ''===================================================================================================

                        tabla = objBu.obtenerIdDescripcionCuentaGeneral(row.Item("CuentaNotaCredito"), empresaSAYContpaqSICY)
                        If tabla.Rows.Count > 0 Then
                            cuentaConceptoCobranzaSAYID = tabla.Rows(0).Item("cuentaSAYID")
                        Else
                            cuentaConceptoCobranzaSAYID = 0
                        End If

                        tabla = objBu.cargarCuentaContableSayClienteNueva(empresaSAYContpaqSICY, row.Item("ClienteId"))

                        If tabla.Rows.Count > 0 Then
                            concepto = tabla.Rows(0).Item("Descripcion")
                        End If
                        listaEntidades = New Entidades.Polizas
                        listaEntidades = extraerUUID(row.Item("RutaXML"))

                        grdCompras.DisplayLayout.Bands(0).AddNew()


                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("CuentaNotaCredito")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TOTAL").Value = row.Item("TOTAL")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteID").Value = row.Item("ClienteId")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("Abonos")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la Cuenta").Value = row.Item("DescripcionCuenta")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = concepto
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "NCR-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = CDbl(row.Item("Subtotal"))
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdNotaCredito").Value = row.Item("IdNotaCredito")
                        If rowRespaldo.Item("TipoMovimiento") = 0 Then
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "P"
                        Else
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "1"
                        End If
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaNotaCredito").Value = row.Item("CuentaNotaCredito")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuenta").Value = row.Item("DescripcionCuenta")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaConceptoCobranzaSAYID

                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color

                        If color = Drawing.Color.White Then
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                        Else
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                        End If

                        contador = 2

                        If contadorRows = 1 And row.Item("TipoCliente") = "NACIONAL" Then
                            ''===================================================================================================
                            ''------------------------------------------AGREGA  IVA-------------------------------------------
                            ''===================================================================================================
                            tabla = objBu.cargarCuentaContableSayClienteNueva(empresaSAYContpaqSICY, rowRespaldo.Item("ClienteID"))

                            If tabla.Rows.Count > 0 Then
                                concepto = tabla.Rows(0).Item("Descripcion")
                            End If

                            listaEntidades = New Entidades.Polizas
                            listaEntidades = extraerUUID(row.Item("RutaXML"))

                            grdCompras.DisplayLayout.Bands(0).AddNew()
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TOTAL").Value = row.Item("TOTAL")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaIVA
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteID").Value = row.Item("ClienteID")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("IVA")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = 0
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = cuentaIVADesc
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = concepto
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "NCR-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = row.Item("IVA")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdNotaCredito").Value = row.Item("IdNotaCredito")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "1"
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = row.Item("RespaldoColor")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentanotacredito").Value = row.Item("cuentanotacredito")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = row.Item("descripcionCuenta")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVASayID
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color

                            If color = Drawing.Color.White Then
                                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                            Else
                                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                            End If
                        End If


                    ElseIf contador = 3 Then

                        If rowRespaldo.Item("TipoCliente") = "NACIONAL" Then
                            ''===================================================================================================
                            ''------------------------------------------AGREGA  IVA-------------------------------------------
                            ''===================================================================================================
                            tabla = objBu.cargarCuentaContableSayClienteNueva(empresaSAYContpaqSICY, rowRespaldo.Item("ClienteID"))

                            If tabla.Rows.Count > 0 Then
                                concepto = tabla.Rows(0).Item("Descripcion")
                            End If

                            listaEntidades = New Entidades.Polizas
                            listaEntidades = extraerUUID(rowRespaldo.Item("RutaXML"))

                            grdCompras.DisplayLayout.Bands(0).AddNew()
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TOTAL").Value = rowRespaldo.Item("TOTAL")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaIVA
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = rowRespaldo.Item("Cliente")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteID").Value = rowRespaldo.Item("ClienteID")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = rowRespaldo.Item("IVA")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = 0
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = cuentaIVADesc
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = concepto
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = rowRespaldo.Item("Fecha")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "NCR-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = rowRespaldo.Item("PolizaSAYID")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = rowRespaldo.Item("PolizaContpaqID")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = rowRespaldo.Item("IVA")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = rowRespaldo.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = rowRespaldo.Item("RutaXML")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = rowRespaldo.Item("RutaPDF")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdNotaCredito").Value = rowRespaldo.Item("IdNotaCredito")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "1"
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = rowRespaldo.Item("RespaldoColor")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentanotacredito").Value = rowRespaldo.Item("cuentanotacredito")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcionCuenta").Value = rowRespaldo.Item("descripcionCuenta")
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVASayID


                            If color = Drawing.Color.White Then
                                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                                grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.LightSteelBlue
                            Else
                                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                                grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.White
                            End If

                        End If

                        ''===================================================================================================
                        ''--------------------------------------------AGREGA CLIENTE--CARGO--------------------------------
                        ''===================================================================================================
                        listaEntidades = New Entidades.Polizas
                        listaEntidades = extraerUUID(row.Item("RutaXML"))

                        grdCompras.DisplayLayout.Bands(0).AddNew()
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TOTAL").Value = row.Item("TOTAL")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("MOVIMIENTO").Value = grdCompras.Rows.Count
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("Cuenta")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteID").Value = row.Item("ClienteID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la Cuenta").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("FACTURA")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "NCR-" + listaEntidades.Pserie.ToString + listaEntidades.Pfolio.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaSAYID").Value = row.Item("PolizaSAYID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = row.Item("PolizaContpaqID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Subtotal").Value = CDbl(row.Item("SUBTOTAL"))
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Rfc").Value = row.Item("Rfc").ToString.Replace("-", "").Replace(" ", "").Trim
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = listaEntidades.Puuid.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = listaEntidades.Pserie.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = listaEntidades.Pfolio.ToString
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaXML").Value = row.Item("RutaXML")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RutaPDF").Value = row.Item("RutaPDF")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdNotaCredito").Value = row.Item("IdNotaCredito")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "0"
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = row.Item("RespaldoColor")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CuentaNotaCredito").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DescripcionCuenta").Value = ""
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = row.Item("cuentaSAYID")
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color

                        If color = Drawing.Color.White Then
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                        Else
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                        End If

                        llenarCuentasClientes(row)

                        rowRespaldo = row

                    End If
                    contadorRows -= 1
                    If row.Item("Fecha") > ultimafecha Then
                        ultimafecha = CDate(row.Item("Fecha"))
                    End If
                End If
            Next

            Dim contadorBanderas As Integer = 0
            Dim contadorBanderas2 As Integer = 0
            lblTotalAbonos2.Text = 0
            lblTotalCargos2.Text = 0

            Dim TotalCargos_NotaCredito, TotalAbonos_NotaCredito As Double
            ' Dim TotalCargos_General, TotalAbonos_General As Double
            Dim diferencia As Double

            TotalCargos_NotaCredito = 0
            TotalAbonos_NotaCredito = 0

            Dim hsNotasCredito As New HashSet(Of String)
            For Each row As UltraGridRow In grdCompras.Rows
                hsNotasCredito.Add(row.Cells("Referencia").Value)
            Next

            For Each item In hsNotasCredito
                diferencia = 0
                TotalCargos_NotaCredito = 0
                TotalAbonos_NotaCredito = 0

                Dim Total As Double
                Dim rowIndexCargo As Integer = 0
                Dim rowIndexAbono As Integer = 0
                Dim IndiceCargoAsignado As Boolean = False

                For Each row As UltraGridRow In grdCompras.Rows
                    If row.Cells("Referencia").Value = item Then
                        If row.Cells("TipoMovimiento").Value = "0" Then
                            If row.Cells("Nombre de la Cuenta").Text = "IVA Pendiente de Cobro" Then
                                rowIndexCargo = row.Index
                            End If

                            Dim CargoActual As String = row.Cells("Cargos").Text
                            TotalCargos_NotaCredito = Math.Round((TotalCargos_NotaCredito + CDbl(CargoActual)), 2)
                        ElseIf row.Cells("TipoMovimiento").Value = "P" Then
                            Total = Math.Round(CDbl(row.Cells("Total").Value), 2)
                            rowIndexAbono = row.Index
                            TotalAbonos_NotaCredito = Math.Round((TotalAbonos_NotaCredito + CDbl(row.Cells("ABONOS").Value)), 2)
                        ElseIf row.Cells("TipoMovimiento").Value = "1" Then
                            TotalAbonos_NotaCredito = Math.Round((TotalAbonos_NotaCredito + CDbl(row.Cells("ABONOS").Value)), 2)
                        End If
                    End If
                Next


                If TotalAbonos_NotaCredito = TotalCargos_NotaCredito Then
                    If Total < TotalAbonos_NotaCredito Then
                        diferencia = Math.Round((TotalCargos_NotaCredito - Total), 2)

                        If diferencia < 1.0 Then
                            If rowIndexCargo = 0 Then
                                grdCompras.Rows(rowIndexCargo).Cells("cargos").Value = CDbl(grdCompras.Rows(rowIndexCargo).Cells("cargos").Value) - diferencia
                                grdCompras.Rows(rowIndexAbono).Cells("abonos").Value = CDbl(grdCompras.Rows(rowIndexAbono).Cells("abonos").Value) - diferencia
                            Else
                                grdCompras.Rows(rowIndexCargo - 1).Cells("cargos").Value = CDbl(grdCompras.Rows(rowIndexCargo - 1).Cells("cargos").Value) - diferencia
                                grdCompras.Rows(rowIndexAbono).Cells("abonos").Value = CDbl(grdCompras.Rows(rowIndexAbono).Cells("abonos").Value) - diferencia
                            End If
                        End If
                    End If
                ElseIf TotalAbonos_NotaCredito > TotalCargos_NotaCredito Then
                    diferencia = Math.Round((TotalAbonos_NotaCredito - TotalCargos_NotaCredito), 2)

                    If diferencia < 1.0 Then
                        If Total = TotalAbonos_NotaCredito Then
                            If rowIndexCargo = 0 Then
                                grdCompras.Rows(rowIndexCargo).Cells("cargos").Value = CDbl(grdCompras.Rows(rowIndexCargo).Cells("cargos").Value) + diferencia
                            Else
                                grdCompras.Rows(rowIndexCargo - 1).Cells("cargos").Value = CDbl(grdCompras.Rows(rowIndexCargo - 1).Cells("cargos").Value) + diferencia
                            End If

                        Else
                            grdCompras.Rows(rowIndexAbono).Cells("abonos").Value = CDbl(grdCompras.Rows(rowIndexAbono).Cells("abonos").Value) - diferencia
                        End If
                    End If
                ElseIf TotalCargos_NotaCredito > TotalAbonos_NotaCredito Then
                    diferencia = Math.Round((TotalCargos_NotaCredito - TotalAbonos_NotaCredito), 2)

                    If diferencia < 1.0 Then
                        If Total = TotalAbonos_NotaCredito Then
                            If rowIndexCargo = 0 Then
                                grdCompras.Rows(rowIndexCargo).Cells("cargos").Value = CDbl(grdCompras.Rows(rowIndexCargo).Cells("cargos").Value) - diferencia
                            Else
                                grdCompras.Rows(rowIndexCargo - 1).Cells("cargos").Value = CDbl(grdCompras.Rows(rowIndexCargo - 1).Cells("cargos").Value) - diferencia
                            End If
                        Else
                            grdCompras.Rows(rowIndexAbono).Cells("abonos").Value = CDbl(grdCompras.Rows(rowIndexAbono).Cells("abonos").Value) + diferencia
                        End If
                    End If
                End If
            Next

            TotalCargos_NotaCredito = 0
            TotalAbonos_NotaCredito = 0

            For Each row As UltraGridRow In grdCompras.Rows
                If row.Cells("Bandera").Value = 0 Then
                    contadorBanderas += 1
                End If
                If row.Cells("Bandera").Value = 2 Then
                    contadorBanderas2 += 1
                End If

                If row.Cells("TipoMovimiento").Value = "0" Then
                    Dim CargoActual As String = row.Cells("Cargos").Value
                    TotalCargos_NotaCredito = Math.Round((TotalCargos_NotaCredito + CDbl(CargoActual)), 2)
                ElseIf row.Cells("TipoMovimiento").Value = "P" Then
                    TotalAbonos_NotaCredito = Math.Round((TotalAbonos_NotaCredito + CDbl(row.Cells("ABONOS").Value)), 2)
                ElseIf row.Cells("TipoMovimiento").Value = "1" Then
                    TotalAbonos_NotaCredito = Math.Round((TotalAbonos_NotaCredito + CDbl(row.Cells("ABONOS").Value)), 2)
                End If
                lblTotalAbonos2.Text = TotalCargos_NotaCredito
                lblTotalCargos2.Text = TotalAbonos_NotaCredito
            Next

            'CODIGO QUE ENVIA DATATABLE A PANTALLA DE VALENTIN
            If lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "Los totales en abonos y cargos no coinciden."
                btnEnvioContp.Enabled = False
                estamal = True
                objMesj.ShowDialog()
            End If

            If contadorBanderas > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas.ToString + " cleinte sin cuenta contable" + vbNewLine + " Favor de relacionarlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas.ToString + " clientes sin cuenta contable" + vbNewLine + " Favor de relacionarlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If contadorBanderas2 > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas2.ToString + " cleinte que no esta dado de alta en SAY" + vbNewLine + " Favor de crearlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas2.ToString + " clientes que no estan dados de alta en SAY" + vbNewLine + " Favor de crearlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If estamal = False Then
                bloquearControles(False)
            Else
                bloquearControles(True)
            End If
        Else
            advertencia.mensaje = "No hay información para mostrar"
            advertencia.ShowDialog()
        End If

    End Sub

    Public Sub llenarTablaNotas_De_Cargo()
        ultimafecha = "01-01-1900"
        estamal = False
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        Dim tablaNotasCargo As New DataTable
        Dim tablaCuentasGenerales As New DataTable
        Dim advertencia As New AdvertenciaForm

        Dim CuentaNotasCargo As String = String.Empty
        Dim CuentaNotasCargo_Nombre As String = String.Empty
        Dim CuentaNotasCargo_IdSay As String = String.Empty

        Dim Concepto As String = String.Empty

        Dim CuentaIVAPendienteCobro As String = ""
        Dim CuentaIVAPendienteCobro_Nombre As String = ""
        Dim CuentaIVAPendienteCobro_IdSAY As String = ""


        Dim color As New System.Drawing.Color
        color = Drawing.Color.White
        fechaDe = dtpDe.Text
        fechaA = dtpAl.Text

        tablaNotasCargo = objBu.CargaGridPolizaNotasDeCargo(doctoVentasID, fechaDe.Date, fechaA.Date, cmbEmpresa.SelectedValue)
        If tablaNotasCargo.Rows.Count > 0 Then
            'BUSCA LA CUENTA GENERAL DE NOTAS DE CARGO
            tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "NOTAS_DE_CARGO", "", tipoPoliza1)
            If tablaCuentasGenerales.Rows.Count > 0 Then
                CuentaNotasCargo = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
                CuentaNotasCargo_Nombre = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
                CuentaNotasCargo_IdSay = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
            Else
                advertencia.mensaje = "Favor de dar de alta la cuenta de notas de cargo para esta empresa."
                advertencia.ShowDialog()
                grdCompras.DataSource = Nothing
                btnEnvioContp.Enabled = False
                estamal = True
                Exit Sub
            End If


            'BUSCA LA CUENTA GENERAL DE IVA PENDIENTE DE COBRO
            tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_COBRO", "", tipoPoliza1)
            If tablaCuentasGenerales.Rows.Count > 0 Then
                CuentaIVAPendienteCobro = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
                CuentaIVAPendienteCobro_Nombre = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
                CuentaIVAPendienteCobro_IdSAY = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
            Else
                advertencia.mensaje = "Favor de dar de alta la cuenta de IVA pendiente de cobro para esta empresa."
                advertencia.ShowDialog()
                grdCompras.DataSource = Nothing
                btnEnvioContp.Enabled = False
                estamal = True
                Exit Sub
            End If

            Dim listParametros As DataTable = tablaNotasCargo.Clone
            grdCompras.DataSource = listParametros
            For Each row As DataRow In tablaNotasCargo.Rows

                'BUSCAR UUID
                Dim objPoliza As New Entidades.Polizas
                objPoliza = extraerUUID(row.Item("rutaXML"))

                'AGREGA CARGO A CUENTA DEL CLIENTE
                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteID").Value = row.Item("ClienteID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SubTotal").Value = row.Item("SubTotal")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la Cuenta").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = objPoliza.Puuid
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = objPoliza.Pserie
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = objPoliza.Pfolio
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = row.Item("Referencia")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaXML").Value = row.Item("rutaXML")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaPDF").Value = row.Item("rutaPDF")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdNotaCargo").Value = row.Item("IdNotaCargo")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentanotacredito").Value = row.Item("cuentanotacredito")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("descripcioncuenta").Value = row.Item("descripcioncuenta")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "0"

                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                End If

                llenarCuentasClientes(row)

                ''=======================================================================================================
                ''--------------------------------AGREGA ABONO A NOTA DE CARGO---------------------------------
                ''=======================================================================================================
                tabla = objBu.cargarCuentaContableSayClienteNueva(empresaSAYContpaqSICY, row.Item("ClienteID"))
                If tabla.Rows.Count > 0 Then
                    Concepto = tabla.Rows(0).Item("Descripcion")
                End If

                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = CuentaNotasCargo
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteID").Value = row.Item("ClienteId")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("SUBTOTAL")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SubTotal").Value = row.Item("SubTotal")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TOTAL").Value = row.Item("TOTAL")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la Cuenta").Value = CuentaNotasCargo_Nombre
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = Concepto
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = objPoliza.Puuid
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = objPoliza.Pserie
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = objPoliza.Pfolio
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = row.Item("Referencia")


                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = "1"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaXML").Value = row.Item("rutaXML")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaPDF").Value = row.Item("rutaPDF")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdNotaCargo").Value = row.Item("IdNotaCargo")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = CuentaNotasCargo_IdSay
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "P"

                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                End If

                ''=======================================================================================================
                ''--------------------------------AGREGA ABONO A IVA PENDIENTE DE COBRO---------------------------------
                ''=======================================================================================================

                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = CuentaIVAPendienteCobro
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteID").Value = row.Item("ClienteId")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SubTotal").Value = row.Item("SubTotal")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la Cuenta").Value = CuentaIVAPendienteCobro_Nombre
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = Concepto
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = objPoliza.Puuid
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = objPoliza.Pserie
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = objPoliza.Pfolio
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = row.Item("Referencia")


                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = "1"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaXML").Value = row.Item("rutaXML")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaPDF").Value = row.Item("rutaPDF")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdNotaCargo").Value = row.Item("IdNotaCargo")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = CuentaIVAPendienteCobro_IdSAY
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("PolizaContpaqID").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "1"

                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    color = Drawing.Color.LightSteelBlue
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    color = Drawing.Color.White
                End If


                If row.Item("FECHA") > ultimafecha Then
                    ultimafecha = row.Item("FECHA")
                End If
            Next

            Dim contadorBanderas As Integer = 0
            Dim contadorBanderas2 As Integer = 0
            lblTotalAbonos2.Text = 0
            lblTotalCargos2.Text = 0

            For Each row As UltraGridRow In grdCompras.Rows
                lblTotalAbonos2.Text = (Math.Round(CDbl(row.Cells("Abonos").Value), 2) + Math.Round(CDbl(lblTotalAbonos2.Text), 2)).ToString("C")
                lblTotalCargos2.Text = (Math.Round(CDbl(row.Cells("CARGOS").Value), 2) + Math.Round(CDbl(lblTotalCargos2.Text), 2)).ToString("C")
                If row.Cells("Bandera").Value = 0 Then
                    contadorBanderas += 1
                End If
                If row.Cells("Bandera").Value = 2 Then
                    contadorBanderas2 += 1
                End If
            Next

            'CODIGO QUE ENVIA DATATABLE A PANTALLA DE VALENTIN
            If lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "Los totales en abonos y cargos no coinciden."
                btnEnvioContp.Enabled = False
                estamal = True
                objMesj.ShowDialog()
            End If

            If contadorBanderas > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas.ToString + " cleinte sin cuenta contable" + vbNewLine + " Favor de relacionarlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas.ToString + " clientes sin cuenta contable" + vbNewLine + " Favor de relacionarlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If contadorBanderas2 > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas2.ToString + " cleinte que no esta dado de alta en SAY" + vbNewLine + " Favor de crearlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas2.ToString + " clientes que no estan dados de alta en SAY" + vbNewLine + " Favor de crearlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If estamal = False Then
                bloquearControles(False)
            Else
                bloquearControles(True)
            End If
        Else
            advertencia.mensaje = "No hay información para mostrar"
            advertencia.ShowDialog()
        End If

    End Sub

    Public Sub llenarTablaChequesPosfechados()
        hsXMLDañados.Clear()
        ultimafecha = "01-01-1900"
        estamal = False
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim dtTablaCheques As New DataTable
        Dim tablaCuentasGenerales As New DataTable
        Dim advertencia As New AdvertenciaForm

        Dim cuentaChequesPosfechados As String = String.Empty
        Dim cuentaChequesPosfechadosDescripcion As String = String.Empty
        Dim cuentaChequesPosfechadosSAYID As String = ""

        Dim rowRespaldo As DataRow

        Dim color As New System.Drawing.Color
        color = Drawing.Color.LightSteelBlue
        fechaDe = dtpDe.Text
        fechaA = dtpAl.Text

        dtTablaCheques = objBu.CargaGridChequesPosfechados(estatus, doctoVentasID, fechaDe.Date, fechaA.Date, cmbEmpresa.SelectedValue)
        If dtTablaCheques.Rows.Count > 0 Then

            'BUSCA LA CUENTA GENERAL DE CHEQUES POSFECHADOS
            tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "CHEQUE_POSFECHADO", "", tipoPoliza1)
            If tablaCuentasGenerales.Rows.Count > 0 Then
                cuentaChequesPosfechados = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
                cuentaChequesPosfechadosDescripcion = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
                cuentaChequesPosfechadosSAYID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
            Else
                advertencia.mensaje = "Favor de dar de alta la cuenta de cheques posfechados para esta empresa."
                advertencia.ShowDialog()
                grdCompras.DataSource = Nothing
                btnEnvioContp.Enabled = False
                estamal = True
                Exit Sub
            End If


            Dim listParametros As DataTable = dtTablaCheques.Clone
            grdCompras.DataSource = listParametros

            rowRespaldo = dtTablaCheques.Rows(0)
            For Each row As DataRow In dtTablaCheques.Rows

                If (grdCompras.Rows.Count = 0) Or (rowRespaldo.Item("Cheque") <> row.Item("Cheque")) Then

                    If color = Drawing.Color.White Then
                        color = Drawing.Color.LightSteelBlue
                    Else
                        color = Drawing.Color.White
                    End If

                    'AGREGA CARGO A CHEQUE

                    grdCompras.DisplayLayout.Bands(0).AddNew()
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaChequesPosfechados
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = cuentaChequesPosfechadosDescripcion
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TotalVenta_?").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cheque").Value = row.Item("Cheque")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = row.Item("Cheque")

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = ""

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "0"
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaXML").Value = row.Item("rutaXML")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaPDF").Value = row.Item("rutaPDF")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteId").Value = row.Item("ClienteId")

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FechaVence").Value = row.Item("FechaVence")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SubtotalAbono").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA_Abono").Value = 0

                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdCheque").Value = row.Item("IdCheque")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CobroId").Value = row.Item("CobroId")
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaChequesPosfechadosSAYID

                    If color = Drawing.Color.White Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    End If

                    Dim clienteDesc As String
                    Dim clienteIDSicy As String
                    Dim dtCliente As DataTable

                    clienteDesc = row.Item("Cliente")
                    clienteIDSicy = row.Item("Clienteid")
                    dtCliente = Nothing

                    dtCliente = objBu.validarclienteExisteSay(clienteIDSicy)

                    If dtCliente.Rows.Count > 0 Then
                        dtCliente = Nothing
                        dtCliente = objBu.cargarCuentaContableSayClienteNueva(empresaSAYContpaqSICY, clienteIDSicy)
                        If dtCliente.Rows.Count > 0 Then
                            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = dtCliente.Rows(0).Item("Descripcion").ToString()
                        End If
                    Else
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 0
                    End If
                End If

                'BUSCAR UUID
                Dim polizaVentas As New Entidades.Polizas
                polizaVentas = extraerUUID(row.Item("rutaXML"))

                If polizaVentas.PrutaXML <> "" Then
                    hsXMLDañados.Add(polizaVentas.PrutaXML + "|Cliente|" + row.Item("Cliente") + "|" + row.Item("Referencia"))
                End If


                'AGREGA ABOINO A FACTURA
                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("Abonos")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TotalVenta_?").Value = row.Item("TotalVenta_?")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("Cheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cheque").Value = row.Item("Cheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = row.Item("Referencia")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Uuid").Value = polizaVentas.Puuid
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Serie").Value = polizaVentas.Pserie
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Folio").Value = polizaVentas.Pfolio

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = "1"
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaXML").Value = row.Item("rutaXML")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("rutaPDF").Value = row.Item("rutaPDF")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("ClienteId").Value = row.Item("ClienteId")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("FechaVence").Value = row.Item("FechaVence")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("SubtotalAbono").Value = row.Item("SubtotalAbono")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA_Abono").Value = row.Item("IVA_Abono")

                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdCheque").Value = row.Item("IdCheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CobroId").Value = row.Item("CobroId")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RemisionID").Value = row.Item("RemisionID")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdVenta").Value = row.Item("IdVenta")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("DoctosVentas").Value = row.Item("DoctosVentas")

                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                End If

                llenarCuentasClientes(row)


                If row.Item("FECHA") > ultimafecha Then
                    ultimafecha = row.Item("FECHA")
                End If

                rowRespaldo = row
            Next

            Dim contadorBanderas As Integer = 0
            Dim contadorBanderas2 As Integer = 0
            lblTotalAbonos2.Text = 0
            lblTotalCargos2.Text = 0

            For Each row As UltraGridRow In grdCompras.Rows
                lblTotalAbonos2.Text = (Math.Round(CDbl(row.Cells("Abonos").Value), 2) + Math.Round(CDbl(lblTotalAbonos2.Text), 2)).ToString("C")
                lblTotalCargos2.Text = (Math.Round(CDbl(row.Cells("CARGOS").Value), 2) + Math.Round(CDbl(lblTotalCargos2.Text), 2)).ToString("C")
                If row.Cells("Bandera").Value = 0 Then
                    contadorBanderas += 1
                End If
                If row.Cells("Bandera").Value = 2 Then
                    contadorBanderas2 += 1
                End If
            Next

            'CODIGO QUE ENVIA DATATABLE A PANTALLA DE VALENTIN
            If lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "Los totales en abonos y cargos no coinciden."
                btnEnvioContp.Enabled = False
                estamal = True
                objMesj.ShowDialog()
            End If


            If hsXMLDañados.Count > 0 Then
                If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "Se encontraron XML dañados, por favor reemplácelos y vuelva a consultar la información de la póliza.") Then
                    Dim objReemplazarXMLDañados As New ReemplazarXMLDañadosForm
                    objReemplazarXMLDañados.hsXMLDañados = hsXMLDañados
                    objReemplazarXMLDañados.StartPosition = FormStartPosition.CenterScreen
                    objReemplazarXMLDañados.ShowDialog()
                End If

                estamal = True
            ElseIf contadorBanderas > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas.ToString + " cleinte sin cuenta contable" + vbNewLine + " Favor de relacionarlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas.ToString + " clientes sin cuenta contable" + vbNewLine + " Favor de relacionarlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If contadorBanderas2 > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas2.ToString + " cleinte que no esta dado de alta en SAY" + vbNewLine + " Favor de crearlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas2.ToString + " clientes que no estan dados de alta en SAY" + vbNewLine + " Favor de crearlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If estamal = False Then
                bloquearControles(False)
            Else
                bloquearControles(True)
            End If
        Else
            advertencia.mensaje = "No hay información para mostrar"
            advertencia.ShowDialog()
        End If

    End Sub

    Public Sub llenarTablaDepositosInternos()
        hsXMLDañados.Clear()
        ultimafecha = "01-01-1900"
        estamal = False
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim dtTablaCheques As New DataTable
        Dim tablaCuentasGenerales As New DataTable
        Dim advertencia As New AdvertenciaForm

        Dim cuentaChequesPosfechados As String = String.Empty
        Dim cuentaChequesPosfechadosDescripcion As String = String.Empty
        Dim cuentaChequesPosfechadosSAYID As String = ""

        Dim cuentaIVATrasladado As String = String.Empty
        Dim cuentaIVATrasladadoDescripcion As String = String.Empty
        Dim cuentaIVATrasladadoSAYID As String = ""

        Dim cuentaIVAPendienteDeCobro As String = String.Empty
        Dim cuentaIVAPendienteDeCobroDescripcion As String = String.Empty
        Dim cuentaIVAPendienteDeCobrioSAYID As String = ""

        Dim rowRespaldo As DataRow

        Dim color As New System.Drawing.Color
        color = Drawing.Color.LightSteelBlue
        fechaDe = dtpDe.Text
        fechaA = dtpAl.Text

        dtTablaCheques = objBu.CargaGridDepositosInternos(estatus, doctoVentasID, fechaDe.Date, fechaA.Date, cmbEmpresa.SelectedValue)
        If dtTablaCheques.Rows.Count > 0 Then

            'BUSCA LA CUENTA GENERAL DE CHEQUES POSFECHADOS
            tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "CHEQUE_POSFECHADO", "", tipoPoliza1)
            If tablaCuentasGenerales.Rows.Count > 0 Then
                cuentaChequesPosfechados = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
                cuentaChequesPosfechadosDescripcion = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
                cuentaChequesPosfechadosSAYID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
            Else
                advertencia.mensaje = "Favor de dar de alta la cuenta de cheques posfechados para esta empresa."
                advertencia.ShowDialog()
                grdCompras.DataSource = Nothing
                btnEnvioContp.Enabled = False
                estamal = True
                Exit Sub
            End If

            'BUSCA LA CUENTA GENERAL DE IVA PENDIENTE DE COBRO
            tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "IVA_PEND_COBRO", "", tipoPoliza1)
            If tablaCuentasGenerales.Rows.Count > 0 Then
                cuentaIVAPendienteDeCobro = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
                cuentaIVAPendienteDeCobroDescripcion = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
                cuentaIVAPendienteDeCobrioSAYID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
            Else
                advertencia.mensaje = "Favor de dar de alta la cuenta de IVA pendiente de cobro para esta empresa."
                advertencia.ShowDialog()
                grdCompras.DataSource = Nothing
                btnEnvioContp.Enabled = False
                estamal = True
                Exit Sub
            End If

            'BUSCA LA CUENTA GENERAL DE IVA TRASLADADO
            tablaCuentasGenerales = objBu.cuentasGenerales(empresaSAYContpaqSICY, "IVA_TRAS", "", tipoPoliza1)
            If tablaCuentasGenerales.Rows.Count > 0 Then
                cuentaIVATrasladado = tablaCuentasGenerales.Rows(0).Item("cgen_cuenta")
                cuentaIVATrasladadoDescripcion = tablaCuentasGenerales.Rows(0).Item("cgen_nombre")
                cuentaIVATrasladadoSAYID = tablaCuentasGenerales.Rows(0).Item("cuentaSAYID")
            Else
                advertencia.mensaje = "Favor de dar de alta la cuenta de IVA trasladado para esta empresa."
                advertencia.ShowDialog()
                grdCompras.DataSource = Nothing
                btnEnvioContp.Enabled = False
                estamal = True
                Exit Sub
            End If


            Dim listParametros As DataTable = dtTablaCheques.Clone
            grdCompras.DataSource = listParametros

            rowRespaldo = dtTablaCheques.Rows(0)
            For Each row As DataRow In dtTablaCheques.Rows

                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = row.Item("CUENTA_CONTPAQ")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = row.Item("NOMBRE_CUENTA_CONTPAQ")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA_CONTPAQ").Value = row.Item("CUENTA_CONTPAQ")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("NOMBRE_CUENTA_CONTPAQ").Value = row.Item("NOMBRE_CUENTA_CONTPAQ")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("Cargos")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Total").Value = row.Item("Total")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "CH-" + row.Item("Cheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cheque").Value = row.Item("Cheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdCheque").Value = row.Item("IdCheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdDocumento").Value = row.Item("IdDocumento")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("EN_POSFECHADOS").Value = row.Item("EN_POSFECHADOS")
                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                End If

                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaIVAPendienteDeCobro
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = cuentaIVAPendienteDeCobroDescripcion
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA_CONTPAQ").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("NOMBRE_CUENTA_CONTPAQ").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Total").Value = row.Item("Total")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "CH-" + row.Item("Cheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cheque").Value = row.Item("Cheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdCheque").Value = row.Item("IdCheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVAPendienteDeCobrioSAYID
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdDocumento").Value = row.Item("IdDocumento")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("EN_POSFECHADOS").Value = row.Item("EN_POSFECHADOS")
                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                End If

                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaIVATrasladado
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = cuentaIVATrasladadoDescripcion
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA_CONTPAQ").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("NOMBRE_CUENTA_CONTPAQ").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Total").Value = row.Item("Total")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "CH-" + row.Item("Cheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cheque").Value = row.Item("Cheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdCheque").Value = row.Item("IdCheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 1
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaIVATrasladado
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdDocumento").Value = row.Item("IdDocumento")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("EN_POSFECHADOS").Value = row.Item("EN_POSFECHADOS")
                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                End If

                grdCompras.DisplayLayout.Bands(0).AddNew()
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Movimiento").Value = grdCompras.Rows.Count
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cuenta").Value = cuentaChequesPosfechados
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = cuentaChequesPosfechadosDescripcion
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA_CONTPAQ").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("NOMBRE_CUENTA_CONTPAQ").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cargos").Value = 0
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Abonos").Value = row.Item("Abonos")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IVA").Value = row.Item("IVA")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Total").Value = row.Item("Total")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Referencia").Value = "CH-" + row.Item("Cheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Fecha").Value = row.Item("Fecha")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cheque").Value = row.Item("Cheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdCheque").Value = row.Item("IdCheque")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("TipoMovimiento").Value = 1
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = cuentaChequesPosfechadosSAYID
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("IdDocumento").Value = row.Item("IdDocumento")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Cliente").Value = row.Item("Cliente")
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("EN_POSFECHADOS").Value = row.Item("EN_POSFECHADOS")


                If color = Drawing.Color.White Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "White"
                    color = Drawing.Color.LightSteelBlue
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = color
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("RespaldoColor").Value = "LightSteelBlue"
                    color = Drawing.Color.White
                End If

                Dim clienteDesc As String
                Dim clienteIDSicy As String
                Dim dtCliente As DataTable

                clienteDesc = row.Item("Cliente")
                clienteIDSicy = row.Item("IdCliente")
                dtCliente = Nothing

                dtCliente = objBu.validarclienteExisteSay(clienteIDSicy)

                If dtCliente.Rows.Count > 0 Then
                    dtCliente = Nothing
                    dtCliente = objBu.cargarCuentaContableSayClienteNueva(empresaSAYContpaqSICY, clienteIDSicy)
                    If dtCliente.Rows.Count > 0 Then
                        grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Concepto").Value = dtCliente.Rows(0).Item("Descripcion").ToString()
                        grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("Concepto").Value = dtCliente.Rows(0).Item("Descripcion").ToString()
                        grdCompras.Rows(grdCompras.Rows.Count - 3).Cells("Concepto").Value = dtCliente.Rows(0).Item("Descripcion").ToString()
                        grdCompras.Rows(grdCompras.Rows.Count - 4).Cells("Concepto").Value = dtCliente.Rows(0).Item("Descripcion").ToString()

                    End If
                Else
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("bandera").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 3).Cells("bandera").Value = 0
                    grdCompras.Rows(grdCompras.Rows.Count - 4).Cells("bandera").Value = 0
                End If


            Next

            Dim contadorBanderas As Integer = 0
            Dim contadorBanderas2 As Integer = 0
            lblTotalAbonos2.Text = 0
            lblTotalCargos2.Text = 0

            For Each row As UltraGridRow In grdCompras.Rows
                lblTotalAbonos2.Text = (Math.Round(CDbl(row.Cells("Abonos").Value), 2) + Math.Round(CDbl(lblTotalAbonos2.Text), 2)).ToString("C")
                lblTotalCargos2.Text = (Math.Round(CDbl(row.Cells("CARGOS").Value), 2) + Math.Round(CDbl(lblTotalCargos2.Text), 2)).ToString("C")
                If row.Cells("Bandera").Value = 0 Then
                    contadorBanderas += 1
                End If
                If row.Cells("Bandera").Value = 2 Then
                    contadorBanderas2 += 1
                End If
            Next

            'CODIGO QUE ENVIA DATATABLE A PANTALLA DE VALENTIN
            If lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "Los totales en abonos y cargos no coinciden."
                btnEnvioContp.Enabled = False
                estamal = True
                objMesj.ShowDialog()
            End If


            If hsXMLDañados.Count > 0 Then
                If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "Se encontraron XML dañados, por favor reemplácelos y vuelva a consultar la información de la póliza.") Then
                    Dim objReemplazarXMLDañados As New ReemplazarXMLDañadosForm
                    objReemplazarXMLDañados.hsXMLDañados = hsXMLDañados
                    objReemplazarXMLDañados.StartPosition = FormStartPosition.CenterScreen
                    objReemplazarXMLDañados.ShowDialog()
                End If

                estamal = True
            ElseIf contadorBanderas > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas.ToString + " cleinte sin cuenta contable" + vbNewLine + " Favor de relacionarlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas.ToString + " clientes sin cuenta contable" + vbNewLine + " Favor de relacionarlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If contadorBanderas2 > 0 Then
                btnEnvioContp.Enabled = False
                estamal = True
                Dim objMesj As New Tools.AdvertenciaForm
                If contadorBanderas = 1 Then
                    objMesj.mensaje = "Existe " + contadorBanderas2.ToString + " cleinte que no esta dado de alta en SAY" + vbNewLine + " Favor de crearlo para poder generar la poliza.  "
                Else
                    objMesj.mensaje = "Existen " + contadorBanderas2.ToString + " clientes que no estan dados de alta en SAY" + vbNewLine + " Favor de crearlos para poder generar la poliza.  "
                End If
                objMesj.ShowDialog()
            End If

            If estamal = False Then
                bloquearControles(False)
            Else
                bloquearControles(True)
            End If
        Else
            advertencia.mensaje = "No hay información para mostrar"
            advertencia.ShowDialog()
        End If

    End Sub

#End Region

#Region "Metodos guardar"

    Public Sub guardarPolizaDepositosIdentificados()
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim fecha As DateTime

        Dim tipoMovimiento As Integer = 0
        Dim cargos As Double = 0
        Dim abonos As Double = 0
        Dim guid As Guid
        Dim polizaID As Integer = 0
        Dim polizaContpaqID As Integer = 0
        Dim folio As String = ""
        Dim referencia As String = ""
        Dim movimientoCFD As Integer = 1


        Dim entidad As New Entidades.Polizas
        Dim tabla As DataTable

        'INSERTA LA POLIZA
        entidad.PservidorBD = servidorBD
        entidad.PempresaBD = empresaBD
        entidad.Pejercicio = ultimafecha.Year
        entidad.Pperiodo = ultimafecha.Month
        entidad.PtipoPolizaCompaq = 3
        entidad.Pconcepto = "Depósitos identificados"
        entidad.Pcargos = lblTotalCargos2.Text
        entidad.Pabonos = lblTotalAbonos2.Text
        entidad.Pfecha = ultimafecha
        entidad.PempresaID = empresaSAYContpaqSICY
        entidad.PdiarioID = 0
        tabla = objBU.AltaPolizaCompaq(entidad)

        'RECUPERA EL ID DE LA POLIZA Y EL GUID DE CONTPAQ
        guid = tabla.Rows(0).Item("GUID")
        folio = tabla.Rows(0).Item("FOLIO")
        polizaContpaqID = tabla.Rows(0).Item("ID")
        entidad.PpolizaCONTPAQID = polizaContpaqID
        entidad.Pguid = guid
        entidad.Pfolio = folio
        entidad.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        entidad.PtipoPoliza = cmbTipo.SelectedValue.ToString

        ''INSERTA POLIZA EN SAY
        tabla = objBU.AltaPolizaSAY(entidad)

        ''RECUPERA EL ID DE LA POLIZA SAY
        polizaID = tabla.Rows(0).Item("polizaID")
        entidad.PpolizaID = polizaID

        'INSERTA LOS MOVIMIENTOS DE POLIZA
        For Each row As UltraGridRow In grdCompras.Rows

            If Not IsDBNull(row.Cells("MOVIMIENTO").Value) Then

                entidad = New Entidades.Polizas

                If IsDBNull(row.Cells("FECHA").Value) Then
                    fecha = ultimafecha
                Else
                    fecha = row.Cells("FECHA").Value
                End If

                If row.Cells("TipoMovimiento").Value = 0 Then
                    tipoMovimiento = 0
                    cargos = row.Cells("CARGOS").Value
                    referencia = row.Cells("FECHA").Value
                    entidad.Pconcepto = row.Cells("Cliente").Value

                Else
                    tipoMovimiento = 1
                    cargos = row.Cells("ABONOS").Value
                    entidad.Pconcepto = ""
                    referencia = row.Cells("SERIE").Value.ToString + row.Cells("FOLIO").Value.ToString
                End If

                entidad.PservidorBD = servidorBD
                entidad.PempresaBD = empresaBD
                entidad.PcuentaContable = row.Cells("CUENTA").Value
                entidad.PpolizaID = polizaID
                entidad.Pfecha = fecha
                entidad.Pejercicio = fecha.Year
                entidad.Pperiodo = fecha.Month

                entidad.PtipoPolizaCompaq = 3
                entidad.PnumMovimiento = row.Cells("MOVIMIENTO").Value
                entidad.PtipoMovimiento = tipoMovimiento
                entidad.Pcargos = cargos

                entidad.Preferencia = referencia

                entidad.PempresaID = empresaSAYContpaqSICY
                entidad.Pfolio = folio
                entidad.PpolizaCONTPAQID = polizaContpaqID
                entidad.Pconcepto = row.Cells("Concepto").Value
                entidad.PdiarioID = 0
                entidad.Preferencia = row.Cells("Referencia").Value
                Dim tablaGuid As DataTable
                tablaGuid = objBU.AltaPolizaMovimientoCompaq(entidad)
                guid = tablaGuid.Rows(0).Item("GUID")


                entidad.Pcargos = row.Cells("CARGOS").Value
                entidad.Pabonos = row.Cells("ABONOS").Value

                ''ALTA MOVIEMTNO SAY
                If IsDBNull(row.Cells("UUID").Value) Then
                    entidad.Puuid = ""
                Else
                    entidad.Puuid = row.Cells("UUID").Value
                End If

                If IsDBNull(row.Cells("XML").Value) Then
                    entidad.PrutaXML = ""
                Else
                    entidad.PrutaXML = row.Cells("XML").Value
                End If

                If IsDBNull(row.Cells("PDF").Value) Then
                    entidad.PrutaPDF = ""
                Else
                    entidad.PrutaPDF = row.Cells("PDF").Value
                End If

                If IsDBNull(row.Cells("cobroID").Value) Then
                    entidad.pcobroid = 0
                Else
                    entidad.pcobroid = row.Cells("cobroID").Value
                End If
                entidad.Pconcepto = "Depósitos identificados"
                entidad.PccSAYID = row.Cells("cuentaSAYID").Value
                entidad.PproveedorSicyID = row.Cells("clienteID").Value
                entidad.PtipoPoliza = cmbTipo.SelectedValue
                entidad.PtransferenciaID = 0
                entidad.PcompraID = 0
                entidad.Preferencia = row.Cells("Referencia").Value
                entidad.PtipoMovimiento = row.Cells("TipoMovimiento").Value
                entidad.Pfecha = row.Cells("Fecha").Value
                objBU.AltaPolizaMovimientoSAY(entidad)

                'INSERTA CGDI
                referencia = ""
                If row.Cells("TipoMovimiento").Value = 1 And row.Cells("UUID").Value.ToString <> "" Then

                    referencia = "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><Referencia><Documento tipo=""MovimientoPoliza"" edoPago=""0"" cadReferencia=""Movimiento de la cuenta: " + row.Cells("CUENTA").Value + ", empresa: " + empresaBD.ToString + ", guid: " + guid.ToString.ToUpper + ".""/></Referencia>"

                    entidad = New Entidades.Polizas

                    entidad.PservidorBD = servidorBD
                    entidad.PempresaBD = empresaBD
                    entidad.Pguid = guid
                    entidad.Puuid = row.Cells("UUID").Value
                    entidad.Preferencia = referencia
                    entidad.PpolizaCONTPAQID = polizaContpaqID
                    objBU.AltaPolizaCFDICompaq(entidad)

                    ''INSERTA MOVIMIENTO CFDI
                    If IsDBNull(row.Cells("SERIE").Value) Then
                        entidad.Pserie = "''"
                    Else
                        entidad.Pserie = row.Cells("SERIE").Value
                    End If
                    entidad.PnumMovimiento = movimientoCFD
                    entidad.Pfecha = row.Cells("FECHA").Value
                    entidad.Pfolio = row.Cells("FOLIO").Value
                    entidad.Puuid = row.Cells("UUID").Value
                    entidad.PpolizaID = polizaID
                    entidad.PproveedorRFC = row.Cells("RFC").Value.ToString.Replace("-", "").Trim
                    '   entidad.Psubtotal = row.Cells("SUBTOTAL").Value
                    entidad.Pabonos = row.Cells("ABONOS").Value
                    '  entidad.Piva = row.Cells("IVA").Value
                    entidad.Preferencia = row.Cells("SERIE").Value.ToString + row.Cells("FOLIO").Value.ToString
                    objBU.AltaPolizaCFDIMovimiento(entidad)
                    movimientoCFD += 1

                End If
            End If
        Next

        objBU.actualizarTotales(servidorBD, empresaBD, polizaContpaqID)

        Dim mensajeExito As New ExitoForm
        mensajeExito.mensaje = "Los depósitos identificados fueron replicados satisfactoriamente."
        mensajeExito.ShowDialog()
        grdCompras.DataSource = Nothing
        LlenadoCombos()
        cmbTipo.SelectedIndex = 0
        estatus = 0
        empresa = 0
        fechaDe = New Date
        fechaA = New Date
        tipo = 0
        bloquearControles(True)
        limpiar()
    End Sub

    Public Sub guardarPolizaDepositosPorIdentificar()
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU

        Dim entidad As New Entidades.Polizas
        Dim tabla As New DataTable
        Dim Guid As Guid
        Dim folio As String = ""
        Dim polizaContpaqID As Integer = 0
        Dim polizaID As Integer = 0
        Dim tipoMovimiento As Integer = 0
        Dim cargos As Double = 0
        Dim abonos As Double = 0
        Dim referencia As String = ""

        entidad.PservidorBD = servidorBD
        entidad.PempresaBD = empresaBD
        entidad.Pejercicio = ultimafecha.Year
        entidad.Pperiodo = ultimafecha.Month
        entidad.PtipoPolizaCompaq = 1
        entidad.Pconcepto = "Depósitos por identificar"
        entidad.Pcargos = abonosAcumulado
        entidad.Pabonos = abonosAcumulado
        entidad.Pfecha = ultimafecha
        entidad.PempresaID = empresaSAYContpaqSICY
        entidad.PdiarioID = 0
        tabla = objBU.AltaPolizaCompaq(entidad)

        'RECUPERA EL ID DE LA POLIZA Y EL GUID DE CONTPAQ
        Guid = tabla.Rows(0).Item("GUID")
        folio = tabla.Rows(0).Item("FOLIO")
        polizaContpaqID = tabla.Rows(0).Item("ID")
        entidad.PpolizaCONTPAQID = polizaContpaqID
        entidad.Pguid = Guid
        entidad.Pfolio = folio
        entidad.PtipoPoliza = cmbTipo.SelectedValue
        entidad.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ''INSERTA POLIZA EN SAY
        tabla = objBU.AltaPolizaSAY(entidad)

        'RECUPERA EL ID DE LA POLIZA SAY
        polizaID = tabla.Rows(0).Item("polizaID")
        entidad.PpolizaID = polizaID

        'INSERTA LOS MOVIMIENTOS DE POLIZA
        For Each row As UltraGridRow In grdCompras.Rows
            entidad = New Entidades.Polizas
            fechaA = ultimafecha
            abonos = 0
            cargos = 0

            If row.Cells("TipoMovimiento").Value = 0 Then
                tipoMovimiento = 0
                cargos = row.Cells("CARGOS").Value
                abonos = 0
            Else
                tipoMovimiento = 1

                cargos = row.Cells("ABONOS").Value
                abonos = row.Cells("ABONOS").Value
            End If

            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.PcuentaContable = row.Cells("CUENTA").Value
            entidad.PpolizaID = polizaID
            entidad.Pfecha = ultimafecha
            entidad.Pejercicio = ultimafecha.Year
            entidad.Pperiodo = ultimafecha.Month
            entidad.PtipoPolizaCompaq = 1
            entidad.PnumMovimiento = row.Cells("MOVIMIENTO").Value
            entidad.PtipoMovimiento = tipoMovimiento
            entidad.Pcargos = cargos
            entidad.Pabonos = abonos
            entidad.Preferencia = ""
            entidad.Pconcepto = ""
            entidad.PempresaID = empresaSAYContpaqSICY
            entidad.Pfolio = folio
            entidad.PpolizaCONTPAQID = polizaContpaqID
            entidad.PdiarioID = 0
            Dim tablaGuid As DataTable
            If row.Cells("CUENTABANCARIA").Value <> "" Then
                If row.Cells("CuentaBancaria").Value <> "" Then
                    entidad.PdiarioID = objBU.RecuperarIdDiarioContpaq("100", servidorBD, empresaBD)
                Else
                    entidad.PdiarioID = 0
                End If
            Else
                entidad.PdiarioID = 0
            End If


            tablaGuid = objBU.AltaPolizaMovimientoCompaq(entidad)
            Guid = tablaGuid.Rows(0).Item("GUID")


            ' ''ALTA MOVIEMTNO SAY

            entidad.Puuid = ""
            entidad.PrutaXML = ""
            entidad.PrutaPDF = ""


            If IsDBNull(row.Cells("MOVIMIENTOID").Value) Then
                entidad.PcompraID = 0
            Else
                entidad.PcompraID = row.Cells("MOVIMIENTOID").Value
            End If

            entidad.Pcargos = row.Cells("CARGOS").Value
            entidad.Pabonos = row.Cells("ABONOS").Value

            entidad.PtipoPoliza = cmbTipo.SelectedValue
            entidad.PccSAYID = row.Cells("cuentaSAYID").Value
            entidad.PtipoMovimiento = row.Cells("TipoMovimiento").Value
            objBU.AltaPolizaMovimientoSAY(entidad)




        Next

        objBU.actualizarTotales(servidorBD, empresaBD, polizaContpaqID)
        objBU.ActualizaCargosAbonosPoliza(polizaID)

        Dim mensajeExito As New ExitoForm
        mensajeExito.mensaje = "Los depósitos por identificar fueron replicados satisfactoriamente."
        mensajeExito.ShowDialog()

        grdCompras.DataSource = Nothing
        LlenadoCombos()
        cmbTipo.SelectedIndex = 0
        estatus = 0
        empresa = 0
        fechaDe = New Date
        fechaA = New Date
        tipo = 0
    End Sub

    Public Sub guardarPolizaCompras()
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim fecha As DateTime

        Dim tipoMovimiento As Integer = 0
        Dim cargos As Double = 0
        Dim abonos As Double = 0
        Dim guid As Guid
        Dim polizaID As Integer = 0
        Dim polizaContpaqID As Integer = 0
        Dim folio As String = ""
        Dim referencia As String = ""
        Dim movimientoCFD As Integer = 1

        Dim entidad As New Entidades.Polizas
        Dim tabla As DataTable

        'INSERTA LA POLIZA
        entidad.PservidorBD = servidorBD
        entidad.PempresaBD = empresaBD
        entidad.Pejercicio = ultimafecha.Year
        entidad.Pperiodo = ultimafecha.Month
        entidad.PtipoPolizaCompaq = 9
        entidad.Pconcepto = "Compras a crédito"
        entidad.Pcargos = subtotalAcumulado + ivaAcumulado
        entidad.Pabonos = abonosAcumulado
        entidad.Pfecha = ultimafecha
        entidad.PempresaID = empresaSAYContpaqSICY
        entidad.PdiarioID = 0
        tabla = objBU.AltaPolizaCompaq(entidad)

        'RECUPERA EL ID DE LA POLIZA Y EL GUID DE CONTPAQ
        guid = tabla.Rows(0).Item("GUID")
        folio = tabla.Rows(0).Item("FOLIO")
        polizaContpaqID = tabla.Rows(0).Item("ID")
        entidad.PpolizaCONTPAQID = polizaContpaqID
        entidad.Pguid = guid
        entidad.Pfolio = folio
        entidad.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        entidad.PtipoPoliza = cmbTipo.SelectedValue.ToString

        ''INSERTA POLIZA EN SAY
        tabla = objBU.AltaPolizaSAY(entidad)

        ''RECUPERA EL ID DE LA POLIZA SAY
        polizaID = tabla.Rows(0).Item("polizaID")
        entidad.PpolizaID = polizaID

        'INSERTA LOS MOVIMIENTOS DE POLIZA
        For Each row As UltraGridRow In grdCompras.Rows

            If Not IsDBNull(row.Cells("MOVIMIENTO").Value) Then

                entidad = New Entidades.Polizas

                If IsDBNull(row.Cells("FECHA").Value) Then
                    fecha = ultimafecha
                Else
                    fecha = row.Cells("FECHA").Value
                End If


                If row.Cells("TipoMovimiento").Value = 0 Then
                    tipoMovimiento = 0
                    cargos = row.Cells("CARGOS").Value
                Else
                    tipoMovimiento = 1
                    cargos = row.Cells("ABONOS").Value
                End If

                If IsDBNull(row.Cells("REFERENCIA").Value) Then
                    referencia = ""
                Else
                    referencia = row.Cells("REFERENCIA").Value
                End If

                entidad.PservidorBD = servidorBD
                entidad.PempresaBD = empresaBD
                entidad.PcuentaContable = row.Cells("CUENTA").Value
                entidad.PpolizaID = polizaID
                entidad.Pfecha = fecha
                entidad.Pejercicio = fecha.Year
                entidad.Pperiodo = fecha.Month

                entidad.PtipoPolizaCompaq = 9
                entidad.PnumMovimiento = row.Cells("MOVIMIENTO").Value
                entidad.PtipoMovimiento = tipoMovimiento
                entidad.Pcargos = cargos

                entidad.Preferencia = referencia
                entidad.Pconcepto = row.Cells("Concepto").Value
                entidad.PempresaID = empresaSAYContpaqSICY
                entidad.Pfolio = folio
                entidad.PpolizaCONTPAQID = polizaContpaqID
                entidad.PdiarioID = 0
                Dim tablaGuid As DataTable
                tablaGuid = objBU.AltaPolizaMovimientoCompaq(entidad)
                guid = tablaGuid.Rows(0).Item("GUID")


                entidad.Pcargos = row.Cells("CARGOS").Value
                entidad.Pabonos = row.Cells("ABONOS").Value


                ''ALTA MOVIEMTNO SAY
                If IsDBNull(row.Cells("UUID").Value) Then
                    entidad.Puuid = ""
                Else
                    entidad.Puuid = row.Cells("UUID").Value
                End If

                If IsDBNull(row.Cells("RutaXML").Value) Then
                    entidad.PrutaXML = ""
                Else
                    entidad.PrutaXML = row.Cells("RutaXML").Value
                End If

                If IsDBNull(row.Cells("RutaPDF").Value) Then
                    entidad.PrutaPDF = ""
                Else
                    entidad.PrutaPDF = row.Cells("RutaPDF").Value
                End If

                If IsDBNull(row.Cells("compraSICYID").Value) Then
                    entidad.PcompraID = 0
                Else
                    entidad.PcompraID = row.Cells("compraSICYID").Value
                End If
                entidad.Pconcepto = row.Cells("Concepto").Value

                entidad.PproveedorSicyID = row.Cells("proveedorSicyID").Value
                entidad.PtipoPoliza = cmbTipo.SelectedValue
                entidad.PtransferenciaID = 0
                entidad.PccSAYID = row.Cells("cuentaSAYID").Value
                entidad.PtipoMovimiento = row.Cells("TipoMovimiento").Value
                entidad.Preferencia = row.Cells("REFERENCIA").Value
                objBU.AltaPolizaMovimientoSAY(entidad)


                ''INSERTA CGDI
                referencia = ""
                If row.Cells("TipoMovimiento").Value = 1 And row.Cells("UUID").Value.ToString <> "" Then

                    referencia = "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><Referencia><Documento tipo=""MovimientoPoliza"" edoPago=""0"" cadReferencia=""Movimiento de la cuenta: " + row.Cells("CUENTA").Value + ", empresa: " + empresaBD.ToString + ", guid: " + guid.ToString.ToUpper + ".""/></Referencia>"

                    entidad = New Entidades.Polizas

                    entidad.PservidorBD = servidorBD
                    entidad.PempresaBD = empresaBD
                    entidad.Pguid = guid
                    entidad.Puuid = row.Cells("UUID").Value
                    entidad.Preferencia = referencia
                    entidad.PpolizaCONTPAQID = polizaContpaqID
                    objBU.AltaPolizaCFDICompaq(entidad)


                    ''INSERTA MOVIMIENTO CFDI
                    If IsDBNull(row.Cells("SERIE").Value) Then
                        entidad.Pserie = "''"
                    Else
                        entidad.Pserie = row.Cells("SERIE").Value
                    End If
                    entidad.PnumMovimiento = movimientoCFD
                    entidad.Pfecha = row.Cells("FECHA").Value
                    entidad.Pfolio = row.Cells("FOLIO").Value
                    entidad.Puuid = row.Cells("UUID").Value
                    entidad.PpolizaID = polizaID
                    entidad.PproveedorRFC = row.Cells("RFC").Value.ToString.Replace("-", "").Trim
                    entidad.Psubtotal = row.Cells("SUBTOTAL").Value
                    entidad.Pabonos = row.Cells("ABONOS").Value
                    entidad.Piva = row.Cells("IVA").Value
                    entidad.Preferencia = row.Cells("REFERENCIA").Value.ToString.Trim
                    objBU.AltaPolizaCFDIMovimiento(entidad)
                    movimientoCFD += 1

                End If



            End If
        Next

        objBU.actualizarTotales(servidorBD, empresaBD, polizaContpaqID)

        Dim mensajeExito As New ExitoForm
        mensajeExito.mensaje = "Las compras fueron replicadas satisfactoriamente."
        mensajeExito.ShowDialog()
        grdCompras.DataSource = Nothing
        LlenadoCombos()
        cmbTipo.SelectedIndex = 0
        estatus = 0
        empresa = 0
        fechaDe = New Date
        fechaA = New Date
        tipo = 0
        bloquearControles(True)
        limpiar()

    End Sub

    Public Sub guardarPolizaTransferencias()
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim fecha As DateTime
        Dim totalSubtotal As Double = 0
        Dim totalIVA As Double = 0

        Dim tipoMovimiento As Integer = 0
        Dim cargos As Double = 0
        Dim abonos As Double = 0
        Dim guid As Guid
        Dim polizaID As Integer = 0
        Dim polizaContpaqID As Integer = 0
        Dim folio As String = ""
        Dim referencia As String = ""
        Dim folioEgresos As Integer = 1
        Dim numMovimientoCFDI As Integer = 1

        Dim entidad As New Entidades.Polizas
        Dim tabla As DataTable

        ''''AGREGAMOS EL ID DEL TIPO DE POLIZA DE LA TRANSFERENCIA CONTPAQ A TODAS LAS COLUMNAS 
        For CONT = grdCompras.Rows.Count To 0 Step -1
            If CONT > 0 Then
                If CONT < grdCompras.Rows.Count Then
                    If grdCompras.Rows(CONT - 1).Cells("TipoPolizaContpaqID").Text = "" Then
                        grdCompras.Rows(CONT - 1).Cells("TipoPolizaContpaqID").Value = grdCompras.Rows(CONT).Cells("TipoPolizaContpaqID").Value
                    End If
                End If
            End If
        Next

        'INSERTA LOS MOVIMIENTOS DE POLIZA
        For Each row As UltraGridRow In grdCompras.Rows

            If row.Cells("Movimiento").Value = 1 Then
                'INSERTA LA POLIZA
                numMovimientoCFDI = 1
                folioEgresos = 1

                entidad.PservidorBD = servidorBD
                entidad.PempresaBD = empresaBD
                entidad.Pejercicio = ultimafecha.Year
                entidad.Pperiodo = ultimafecha.Month
                entidad.PtipoPolizaCompaq = row.Cells("TipoPolizaContpaqID").Value
                entidad.Pconcepto = "Pago a proveedores"
                entidad.Pcargos = CDbl(lblTotalCargos2.Text)
                entidad.Pabonos = CDbl(lblTotalAbonos2.Text)
                entidad.Pfecha = ultimafecha
                entidad.PempresaID = empresaSAYContpaqSICY
                entidad.PdiarioID = 0
                tabla = objBU.AltaPolizaCompaq(entidad)

                'RECUPERA EL ID DE LA POLIZA Y EL GUID DE CONTPAQ
                guid = tabla.Rows(0).Item("GUID")
                folio = tabla.Rows(0).Item("FOLIO")
                polizaContpaqID = tabla.Rows(0).Item("ID")
                entidad.PpolizaCONTPAQID = polizaContpaqID
                entidad.Pguid = guid
                entidad.Pfolio = folio
                entidad.PtipoPoliza = cmbTipo.SelectedValue.ToString '12
                entidad.Pcargos = CDbl(lblTotalCargos2.Text)
                entidad.Pabonos = CDbl(lblTotalAbonos2.Text)
                entidad.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                ''INSERTA POLIZA EN SAY
                tabla = objBU.AltaPolizaSAY(entidad)
                ''RECUPERA EL ID DE LA POLIZA SAY
                polizaID = tabla.Rows(0).Item("polizaID")
                entidad.PpolizaID = polizaID
            End If

            entidad = New Entidades.Polizas

            If IsDBNull(row.Cells("FECHA").Value) Then
                fecha = ultimafecha
            Else
                fecha = row.Cells("FECHA").Value
            End If

            If row.Cells("TipoMovimiento").Value = 0 Then
                tipoMovimiento = 0
                cargos = row.Cells("CARGOS").Value
            Else
                tipoMovimiento = 1
                cargos = row.Cells("ABONOS").Value
            End If

            If IsDBNull(row.Cells("REFERENCIA").Value) Then
                referencia = ""
            Else
                referencia = row.Cells("REFERENCIA").Value
            End If

            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.PcuentaContable = row.Cells("CUENTA").Value
            entidad.PpolizaID = polizaID
            entidad.Pfecha = fecha
            entidad.Pejercicio = fecha.Year
            entidad.Pperiodo = fecha.Month

            entidad.PtipoPolizaCompaq = row.Cells("TipoPolizaContpaqID").Value
            entidad.PnumMovimiento = row.Cells("MOVIMIENTO").Value
            entidad.PtipoMovimiento = tipoMovimiento
            entidad.Pcargos = cargos

            entidad.Preferencia = referencia
            entidad.Pconcepto = row.Cells("Concepto").Value

            entidad.Pfolio = folio
            entidad.PpolizaCONTPAQID = polizaContpaqID
            entidad.PempresaID = empresaSAYContpaqSICY

            If row.Cells("CuentaBancaria").Value <> "" Then
                entidad.PdiarioID = objBU.RecuperarIdDiarioContpaq("1", servidorBD, empresaBD)
            Else
                entidad.PdiarioID = 0
            End If

            Dim tablaGUID As New DataTable
            tablaGUID = objBU.AltaPolizaMovimientoCompaq(entidad)
            guid = tablaGUID.Rows(0).Item("GUID")

            entidad.Pguid = guid
            entidad.Pcargos = row.Cells("CARGOS").Value
            entidad.Pabonos = row.Cells("ABONOS").Value

            ''ALTA MOVIEMTNO SAY
            If IsDBNull(row.Cells("UUID").Value) Then
                entidad.Puuid = ""
            Else
                entidad.Puuid = row.Cells("UUID").Value
            End If

            If IsDBNull(row.Cells("RutaXML").Value) Then
                entidad.PrutaXML = ""
            Else
                entidad.PrutaXML = row.Cells("RutaXML").Value
            End If

            If IsDBNull(row.Cells("RutaPDF").Value) Then
                entidad.PrutaPDF = ""
            Else
                entidad.PrutaPDF = row.Cells("RutaPDF").Value
            End If

            If IsDBNull(row.Cells("idTransferencia").Value) Then
                entidad.PtransferenciaID = 0
            Else
                entidad.PtransferenciaID = row.Cells("idTransferencia").Value
            End If

            entidad.PproveedorSicyID = row.Cells("proveedorSicyID").Value
            entidad.PtipoPoliza = cmbTipo.SelectedValue
            entidad.PcompraID = 0
            entidad.PccSAYID = row.Cells("cuentaSAYID").Value
            entidad.PtipoMovimiento = row.Cells("TipoMovimiento").Value
            entidad.Preferencia = row.Cells("REFERENCIA").Value
            objBU.AltaPolizaMovimientoSAY(entidad)

            ''INSERTA CGDI
            referencia = ""

            If row.Cells("TipoMovimiento").Value = 0 And row.Cells("UUID").Value.ToString <> "" Then
                referencia = "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><Referencia><Documento tipo=""MovimientoPoliza"" edoPago=""0"" cadReferencia=""Movimiento de la cuenta: " + row.Cells("CUENTA").Value + ", empresa: " + empresaBD.ToString + ", guid: " + guid.ToString.ToUpper + ".""/></Referencia>"
                entidad = New Entidades.Polizas
                entidad.PservidorBD = servidorBD
                entidad.PempresaBD = empresaBD
                entidad.Pguid = guid
                entidad.Puuid = row.Cells("UUID").Value
                entidad.Preferencia = referencia
                entidad.PpolizaCONTPAQID = polizaContpaqID
                entidad.PtransferenciaID = row.Cells("idTransferencia").Value
                entidad.PcompraID = 0
                objBU.AltaPolizaCFDICompaq(entidad)

                ''INSERTA MOVIMIENTO CFDI   
                If IsDBNull(row.Cells("SERIE").Value) Then
                    entidad.Pserie = "''"
                Else
                    entidad.Pserie = row.Cells("SERIE").Value
                End If
                entidad.PnumMovimiento = numMovimientoCFDI
                entidad.Pfecha = row.Cells("FECHA").Value
                entidad.Pfolio = row.Cells("FOLIO").Value
                entidad.Puuid = row.Cells("UUID").Value
                entidad.PpolizaID = polizaID
                entidad.PproveedorRFC = row.Cells("RFC").Value.ToString.Replace("-", "").Trim
                entidad.Psubtotal = row.Cells("SUBTOTAL").Value
                entidad.Pabonos = row.Cells("CARGOS").Value
                entidad.Piva = row.Cells("IVA").Value
                entidad.Preferencia = row.Cells("REFERENCIA").Value
                objBU.AltaPolizaCFDIMovimiento(entidad)

                numMovimientoCFDI += 1

            ElseIf row.Cells("TipoMovimiento").Value = 1 And row.Cells("ClabeInterbancaria").Value.ToString.Length > 5 Then
                entidad.PproveedorRFC = row.Cells("RFC").Value.ToString.Replace("-", "").Trim.ToUpper

                entidad.Pfecha = fecha
                entidad.Pejercicio = fecha.Year
                entidad.Pperiodo = fecha.Month
                entidad.PCuentaGeneralContpaqid = row.Cells("CuentaContpaqid").Value.ToString
                entidad.PtotalPoliza = totalSubtotal + totalIVA
                entidad.Preferencia = row.Cells("NumAutorizacion").Value.ToString
                entidad.Pconcepto = row.Cells("Concepto").Value.ToString
                entidad.PtotalPoliza = CDbl(lblTotalAbonos2.Text)
                entidad.PpolizaCONTPAQID = polizaContpaqID
                entidad.PclabeInterbancaria = row.Cells("ClabeInterbancaria").Value
                entidad.PbancoContpaqid = row.Cells("bancoContpaqid").Value
                entidad.Pfolio = folioEgresos
                'objBU.AltaMovimientoEgresos(entidad, servidorBD, empresaBD)
                objBU.actualizarTotales(servidorBD, empresaBD, polizaContpaqID)
                objBU.ActualizaCargosAbonosPoliza(entidad.PpolizaID)
                folioEgresos += 1
            End If

            'If row.Cells("tipoPolizaContpaqID").Value <> "" Then
            '    objBU.ActualizaTipoPoliza(polizaContpaqID, row.Cells("tipoPolizaContpaqID").Value, servidorBD, empresaBD)
            'End If


        Next
        'objBU.actualizarTotales(servidorBD, empresaBD, polizaContpaqID)
        Dim mensajeExito As New ExitoForm
        mensajeExito.mensaje = "Las transferencias fueron replicadas satisfactoriamente."
        mensajeExito.ShowDialog()

        grdCompras.DataSource = Nothing
        LlenadoCombos()
        limpiar()
        cmbTipo.SelectedIndex = 0
        estatus = 0
        empresa = 0
        fechaDe = New Date
        fechaA = New Date
        tipo = 0

    End Sub

    Public Sub guardarPolizaVentas()

        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim fecha As DateTime

        Dim tipoMovimiento As Integer = 0
        Dim cargos As Double = 0
        Dim abonos As Double = 0
        Dim guid As Guid
        Dim polizaID As Integer = 0
        Dim polizaContpaqID As Integer = 0
        Dim tipoPolizaContpaqID As Integer = 0
        Dim folio As String = ""
        Dim referencia As String = ""
        Dim movimientoCFD As Integer = 1

        Dim entidad As New Entidades.Polizas
        Dim tabla As DataTable = grdCompras.DataSource

        tipoPolizaContpaqID = objBU.RecuperarCodigoTipoPolizaContpaq("Ventas", servidorBD, empresaBD)

        If tipoPolizaContpaqID > 0 Then
            'INSERTA LA POLIZA
            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.Pejercicio = ultimafecha.Year
            entidad.Pperiodo = ultimafecha.Month
            entidad.PtipoPolizaCompaq = tipoPolizaContpaqID
            entidad.Pconcepto = "Ventas a crédito"
            entidad.Pcargos = CDbl(lblTotalCargos2.Text)
            entidad.Pabonos = CDbl(lblTotalAbonos2.Text)
            entidad.Pfecha = ultimafecha
            entidad.PempresaID = empresaSAYContpaqSICY

            tabla = objBU.AltaPolizaCompaq(entidad)

            'RECUPERA EL ID DE LA POLIZA Y EL GUID DE CONTPAQ
            guid = tabla.Rows(0).Item("GUID")
            folio = tabla.Rows(0).Item("FOLIO")
            polizaContpaqID = tabla.Rows(0).Item("ID")
            entidad.PpolizaCONTPAQID = polizaContpaqID
            entidad.Pguid = guid
            entidad.Pfolio = folio
            entidad.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.PdiarioID = 0
            entidad.PtipoPoliza = cmbTipo.SelectedValue.ToString

            ''INSERTA POLIZA EN SAY
            tabla = objBU.AltaPolizaSAY(entidad)

            ''RECUPERA EL ID DE LA POLIZA SAY
            polizaID = tabla.Rows(0).Item("polizaID")
            entidad.PpolizaID = polizaID

            'INSERTA LOS MOVIMIENTOS DE POLIZA
            For Each row As UltraGridRow In grdCompras.Rows

                If Not IsDBNull(row.Cells("MOVIMIENTO").Value) Then

                    entidad = New Entidades.Polizas

                    If IsDBNull(row.Cells("FECHA").Value) Then
                        fecha = ultimafecha
                    Else
                        fecha = row.Cells("FECHA").Value
                    End If

                    If row.Cells("TipoMovimiento").Value = 0 Then
                        tipoMovimiento = 0
                        cargos = row.Cells("CARGOS").Value
                    Else
                        tipoMovimiento = 1
                        cargos = row.Cells("ABONOS").Value
                    End If

                    If IsDBNull(row.Cells("REFERENCIA").Value) Then
                        referencia = ""
                    Else
                        referencia = row.Cells("REFERENCIA").Value
                    End If

                    entidad.PservidorBD = servidorBD
                    entidad.PempresaBD = empresaBD
                    entidad.PcuentaContable = LTrim(RTrim(row.Cells("CUENTA").Value))
                    entidad.PpolizaID = polizaID
                    entidad.Pfecha = fecha
                    entidad.Pejercicio = fecha.Year
                    entidad.Pperiodo = fecha.Month

                    entidad.PtipoPolizaCompaq = tipoPolizaContpaqID
                    entidad.PnumMovimiento = row.Cells("MOVIMIENTO").Value
                    entidad.PtipoMovimiento = tipoMovimiento
                    entidad.Pcargos = cargos

                    entidad.Preferencia = referencia
                    entidad.Pconcepto = row.Cells("Concepto").Value
                    entidad.PempresaID = empresaSAYContpaqSICY
                    entidad.Pfolio = folio
                    entidad.PpolizaCONTPAQID = polizaContpaqID
                    entidad.PdiarioID = 0
                    Dim tablaGuid As DataTable
                    tablaGuid = objBU.AltaPolizaMovimientoCompaq(entidad)
                    guid = tablaGuid.Rows(0).Item("GUID")


                    entidad.Pcargos = row.Cells("CARGOS").Value
                    entidad.Pabonos = row.Cells("ABONOS").Value

                    ''ALTA MOVIEMTNO SAY
                    If IsDBNull(row.Cells("UUID").Value) Then
                        entidad.Puuid = ""
                    Else
                        entidad.Puuid = row.Cells("UUID").Value
                    End If

                    If IsDBNull(row.Cells("RutaXML").Value) Then
                        entidad.PrutaXML = ""
                    Else
                        entidad.PrutaXML = row.Cells("RutaXML").Value
                    End If

                    If IsDBNull(row.Cells("RutaPDF").Value) Then
                        entidad.PrutaPDF = ""
                    Else
                        entidad.PrutaPDF = row.Cells("RutaPDF").Value
                    End If




                    entidad.Pconcepto = row.Cells("Concepto").Value

                    entidad.PproveedorSicyID = row.Cells("clienteID").Value
                    entidad.PtipoPoliza = cmbTipo.SelectedValue
                    entidad.PccSAYID = row.Cells("cuentaSAYID").Value
                    entidad.PcompraID = 0
                    entidad.PtransferenciaID = 0
                    entidad.pcobroid = 0
                    entidad.PventaID = row.Cells("idVenta").Value
                    entidad.PtipoMovimiento = row.Cells("TipoMovimiento").Value
                    entidad.Preferencia = row.Cells("REFERENCIA").Value
                    objBU.AltaPolizaMovimientoSAY(entidad)

                    ''INSERTA CGDI
                    referencia = ""
                    If row.Cells("TipoMovimiento").Value = 0 And row.Cells("UUID").Value.ToString <> "" Then

                        referencia = "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><Referencia><Documento tipo=""MovimientoPoliza"" edoPago=""0"" cadReferencia=""Movimiento de la cuenta: " + row.Cells("CUENTA").Value + ", empresa: " + empresaBD.ToString + ", guid: " + guid.ToString.ToUpper + ".""/></Referencia>"

                        entidad = New Entidades.Polizas

                        entidad.PservidorBD = servidorBD
                        entidad.PempresaBD = empresaBD
                        entidad.Pguid = guid
                        entidad.Puuid = row.Cells("UUID").Value
                        entidad.Preferencia = referencia
                        entidad.PpolizaCONTPAQID = polizaContpaqID
                        objBU.AltaPolizaCFDICompaq(entidad)


                        ''INSERTA MOVIMIENTO CFDI

                        If IsDBNull(row.Cells("SERIE").Value) Then
                            entidad.Pserie = "''"
                        Else
                            entidad.Pserie = row.Cells("SERIE").Value
                        End If
                        entidad.PnumMovimiento = movimientoCFD
                        entidad.Pfecha = row.Cells("FECHA").Value
                        entidad.Pfolio = row.Cells("FOLIO").Value
                        entidad.Puuid = row.Cells("UUID").Value
                        entidad.PpolizaID = polizaID
                        entidad.PproveedorRFC = row.Cells("RFC").Value.ToString.Replace("-", "").Trim
                        entidad.Psubtotal = row.Cells("SUBTOTAL").Value

                        If row.Cells("abonos").Value = 0 Then
                            entidad.Pabonos = row.Cells("cargos").Value
                        Else
                            entidad.Pabonos = row.Cells("ABONOS").Value
                        End If

                        entidad.Piva = row.Cells("IVA").Value
                        entidad.Preferencia = row.Cells("REFERENCIA").Value.ToString.Trim
                        objBU.AltaPolizaCFDIMovimiento(entidad)
                        movimientoCFD += 1

                    End If
                End If
            Next

            objBU.actualizarTotales(servidorBD, empresaBD, polizaContpaqID)

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Las ventas fueron replicadas satisfactoriamente."
            mensajeExito.ShowDialog()
            grdCompras.DataSource = Nothing
            LlenadoCombos()
            cmbTipo.SelectedIndex = 0
            estatus = 0
            empresa = 0
            fechaDe = New Date
            fechaA = New Date
            tipo = 0
            bloquearControles(True)
            limpiar()
        Else
            Dim objAdvertencia As New AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "No se encontro el tipo de poliza de 'Ventas' en la base de datos de Contpaq"
            objAdvertencia.ShowDialog()

        End If

    End Sub

    Public Sub guardarPolizaGastos(ByVal tipoPoliza As Integer, ByVal conceptoPoliza As String)
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim tipoMovimiento As Integer = 0
        Dim cargos As Double = 0
        Dim abonos As Double = 0
        Dim guid As Guid
        Dim polizaID As Integer = 0
        Dim polizaContpaqID As Integer = 0
        Dim folio As String = ""
        Dim referencia As String = ""
        Dim movimientoCFD As Integer = 1
        Dim fecha As DateTime
        'Dim dtCuentasActivoFijo
        Dim entidad As New Entidades.Polizas
        Dim tabla, dtTablaCuentasActivoFijo As DataTable



        If tipoPoliza = 19 Then
            dtTablaCuentasActivoFijo = objBU.CuentasContables_ActivoFijo(cmbEmpresa.SelectedValue)
        End If


        'INSERTA LA POLIZA
        entidad.PservidorBD = servidorBD
        entidad.PempresaBD = empresaBD
        entidad.Pejercicio = ultimafecha.Year
        entidad.Pperiodo = ultimafecha.Month

        entidad.PtipoPolizaCompaq = tipoPoliza

        entidad.Pconcepto = conceptoPoliza

        entidad.Pcargos = CDbl(lblTotalCargos2.Text)
        entidad.Pabonos = CDbl(lblTotalAbonos2.Text)
        entidad.Pfecha = ultimafecha
        entidad.PempresaID = empresaSAYContpaqSICY

        tabla = objBU.AltaPolizaCompaq(entidad)

        'RECUPERA EL ID DE LA POLIZA Y EL GUID DE CONTPAQ
        guid = tabla.Rows(0).Item("GUID")
        folio = tabla.Rows(0).Item("FOLIO")
        polizaContpaqID = tabla.Rows(0).Item("ID")
        entidad.PpolizaCONTPAQID = polizaContpaqID
        entidad.Pguid = guid
        entidad.Pfolio = folio
        entidad.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        entidad.PdiarioID = 0
        entidad.PtipoPoliza = cmbTipo.SelectedValue.ToString

        ''INSERTA POLIZA EN SAY
        tabla = objBU.AltaPolizaSAY(entidad)

        ''RECUPERA EL ID DE LA POLIZA SAY
        polizaID = tabla.Rows(0).Item("polizaID")
        entidad.PpolizaID = polizaID

        For Each row As UltraGridRow In grdCompras.Rows

            entidad = New Entidades.Polizas
            fecha = row.Cells("FECHA").Value

            If row.Cells("TipoMovimiento").Value = 0 Then
                tipoMovimiento = 0
                cargos = row.Cells("CARGOS").Value
            Else
                tipoMovimiento = 1
                cargos = row.Cells("ABONOS").Value
            End If

            Dim dtTablaProveedorContpaq As New DataTable
            ''dtTablaProveedorContpaq = objBU

            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.PcuentaContable = row.Cells("CUENTA").Value
            entidad.PpolizaID = polizaID
            entidad.Pfecha = fecha
            entidad.Pejercicio = fecha.Year
            entidad.Pperiodo = fecha.Month
            entidad.PtipoPolizaCompaq = tipoPoliza
            entidad.PnumMovimiento = row.Cells("MOVIMIENTO").Value
            entidad.PtipoMovimiento = tipoMovimiento
            entidad.Pcargos = cargos
            entidad.Preferencia = row.Cells("REFERENCIA").Value
            entidad.Pconcepto = row.Cells("Concepto").Value
            entidad.PempresaID = empresaSAYContpaqSICY
            entidad.Pfolio = folio
            entidad.PpolizaCONTPAQID = polizaContpaqID
            entidad.PdiarioID = 0
            Dim tablaGuid As DataTable
            tablaGuid = objBU.AltaPolizaMovimientoCompaq(entidad)
            guid = tablaGuid.Rows(0).Item("GUID")


            entidad.Pcargos = row.Cells("CARGOS").Value
            entidad.Pabonos = row.Cells("ABONOS").Value

            ''ALTA MOVIEMTNO SAY
            entidad.Puuid = row.Cells("UUID").Value
            entidad.PrutaXML = row.Cells("RutaXML").Value

            entidad.PrutaPDF = row.Cells("RutaPDF").Value
            entidad.PcompraID = row.Cells("compraSICYID").Value
            entidad.Pconcepto = row.Cells("Concepto").Value

            entidad.PproveedorSicyID = row.Cells("proveedorSicyID").Value
            entidad.PtipoPoliza = cmbTipo.SelectedValue
            entidad.PtransferenciaID = 0
            entidad.PccSAYID = row.Cells("cuentaSAYID").Value
            entidad.PtipoMovimiento = row.Cells("TipoMovimiento").Value
            entidad.Preferencia = row.Cells("REFERENCIA").Value
            objBU.AltaPolizaMovimientoSAY(entidad)


            ''INSERTA CGDI
            referencia = ""
            'If row.Cells("TipoMovimiento").Value = 1 And row.Cells("UUID").Value.ToString <> "" Then

            referencia = "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><Referencia><Documento tipo=""MovimientoPoliza"" edoPago=""0"" cadReferencia=""Movimiento de la cuenta: " + row.Cells("CUENTA").Value + ", empresa: " + empresaBD.ToString + ", guid: " + guid.ToString.ToUpper + ".""/></Referencia>"

            entidad = New Entidades.Polizas

            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.Pguid = guid
            entidad.Puuid = row.Cells("UUID").Value
            entidad.Preferencia = referencia
            entidad.PpolizaCONTPAQID = polizaContpaqID
            objBU.AltaPolizaCFDICompaq(entidad)

            If row.Cells("TipoCompra").Value = "P" Then
                ''grdCompras.DataSource = 
                ''INSERTA MOVIMIENTO CFDI       
                Dim IVA As Double = ((CDbl(row.Cells("ABONOS").Value) / 116) * 16)
                Dim cAbonos As Double = CDbl(row.Cells("ABONOS").Value)
                IVA = Int(IVA * 10 ^ 2 + 1 / 2) / 10 ^ 2

                'If tipoPoliza = 20 Or tipoPoliza = 26 Then
                '    IVA = (CDbl(row.Cells("ABONOS").Value) * 0.16)
                'Else
                '    IVA = Int(IVA * 10 ^ 2 + 1 / 2) / 10 ^ 2
                'End If

                entidad.Pserie = row.Cells("SERIE").Value
                entidad.PnumMovimiento = movimientoCFD
                entidad.Pfecha = row.Cells("FECHA").Value
                entidad.Pfolio = row.Cells("FOLIO").Value
                entidad.Puuid = row.Cells("UUID").Value
                entidad.PpolizaID = polizaID
                entidad.PproveedorRFC = row.Cells("RFC").Value.ToString.Replace("-", "").Trim
                entidad.Psubtotal = row.Cells("SUBTOTAL").Value

                entidad.Pabonos = cAbonos
                entidad.Piva = IVA
                entidad.Preferencia = row.Cells("REFERENCIA").Value.ToString.Trim
                objBU.AltaPolizaCFDIMovimiento(entidad)
                movimientoCFD += 1
            ElseIf row.Cells("TipoCompra").Value = "P" Then
                entidad.Piva = (CDbl(row.Cells("ABONOS").Value) * 0.16)

            End If
        Next

        'objBU.actualizarTotales(servidorBD, empresaBD, polizaContpaqID)

        Dim mensajeExito As New ExitoForm
        mensajeExito.mensaje = "Los gastos fueron replicados satisfactoriamente."
        mensajeExito.ShowDialog()
        grdCompras.DataSource = Nothing
        LlenadoCombos()
        cmbTipo.SelectedIndex = 0
        estatus = 0
        empresa = 0
        fechaDe = New Date
        fechaA = New Date
        tipo = 0
        bloquearControles(True)
        limpiar()

    End Sub

    Public Sub guardarPolizaNotasCredito(ByVal tipoPoliza As Integer, ByVal conceptoPoliza As String)
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim tipoMovimiento As Integer = 0
        Dim cargos As Double = 0
        Dim abonos As Double = 0
        Dim guid As Guid
        Dim polizaID As Integer = 0
        Dim polizaContpaqID As Integer = 0
        Dim folio As String = ""
        Dim referencia As String = ""
        Dim movimientoCFD As Integer = 1
        Dim fecha As DateTime
        Dim entidad As New Entidades.Polizas
        Dim tabla As DataTable


        'INSERTA LA POLIZA
        entidad.PservidorBD = servidorBD
        entidad.PempresaBD = empresaBD
        entidad.Pejercicio = ultimafecha.Year
        entidad.Pperiodo = ultimafecha.Month

        entidad.PtipoPolizaCompaq = tipoPoliza

        entidad.Pconcepto = conceptoPoliza

        entidad.Pcargos = CDbl(lblTotalCargos2.Text)
        entidad.Pabonos = CDbl(lblTotalAbonos2.Text)
        entidad.Pfecha = ultimafecha
        entidad.PempresaID = empresaSAYContpaqSICY

        tabla = objBU.AltaPolizaCompaq(entidad)

        'RECUPERA EL ID DE LA POLIZA Y EL GUID DE CONTPAQ
        guid = tabla.Rows(0).Item("GUID")
        folio = tabla.Rows(0).Item("FOLIO")
        polizaContpaqID = tabla.Rows(0).Item("ID")
        entidad.PpolizaCONTPAQID = polizaContpaqID
        entidad.Pguid = guid
        entidad.Pfolio = folio
        entidad.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        entidad.PdiarioID = 0
        entidad.PtipoPoliza = cmbTipo.SelectedValue.ToString

        ''INSERTA POLIZA EN SAY
        tabla = objBU.AltaPolizaSAY(entidad)

        ''RECUPERA EL ID DE LA POLIZA SAY
        polizaID = tabla.Rows(0).Item("polizaID")
        entidad.PpolizaID = polizaID

        For Each row As UltraGridRow In grdCompras.Rows

            entidad = New Entidades.Polizas
            fecha = row.Cells("FECHA").Value

            If row.Cells("TipoMovimiento").Value = "0" Then
                tipoMovimiento = 0
                cargos = row.Cells("CARGOS").Value
            Else
                tipoMovimiento = 1
                cargos = row.Cells("ABONOS").Value
            End If


            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.PcuentaContable = row.Cells("CUENTA").Value
            entidad.PpolizaID = polizaID
            entidad.Pfecha = fecha
            entidad.Pejercicio = fecha.Year
            entidad.Pperiodo = fecha.Month
            entidad.PtipoPolizaCompaq = tipoPoliza
            entidad.PnumMovimiento = row.Cells("MOVIMIENTO").Value
            entidad.PtipoMovimiento = tipoMovimiento
            entidad.Pcargos = cargos
            entidad.Preferencia = row.Cells("REFERENCIA").Value
            entidad.Pconcepto = row.Cells("Concepto").Value
            entidad.PempresaID = empresaSAYContpaqSICY
            entidad.Pfolio = folio
            entidad.PpolizaCONTPAQID = polizaContpaqID
            entidad.PdiarioID = 0

            Dim tablaGuid As DataTable
            tablaGuid = objBU.AltaPolizaMovimientoCompaq(entidad)
            guid = tablaGuid.Rows(0).Item("GUID")


            entidad.Pcargos = row.Cells("CARGOS").Value
            entidad.Pabonos = row.Cells("ABONOS").Value

            ''ALTA MOVIEMTNO SAY
            entidad.Puuid = row.Cells("UUID").Value
            entidad.PrutaXML = row.Cells("RutaXML").Value

            entidad.PrutaPDF = row.Cells("RutaPDF").Value
            entidad.PNotaCredito = row.Cells("IdNotaCredito").Value
            entidad.Pconcepto = row.Cells("Concepto").Value

            entidad.PtipoPoliza = cmbTipo.SelectedValue
            entidad.PtransferenciaID = 0
            entidad.PccSAYID = row.Cells("cuentaSAYID").Value
            If row.Cells("TipoMovimiento").Value = "P" Then
                entidad.PtipoMovimiento = 1
            Else
                entidad.PtipoMovimiento = row.Cells("TipoMovimiento").Value
            End If

            entidad.Preferencia = row.Cells("REFERENCIA").Value
            objBU.AltaPolizaMovimientoSAY(entidad)


            ''INSERTA CGDI
            referencia = ""
            'If row.Cells("TipoMovimiento").Value = 1 And row.Cells("UUID").Value.ToString <> "" Then

            referencia = "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><Referencia><Documento tipo=""MovimientoPoliza"" edoPago=""0"" cadReferencia=""Movimiento de la cuenta: " + row.Cells("CUENTA").Value + ", empresa: " + empresaBD.ToString + ", guid: " + guid.ToString.ToUpper + ".""/></Referencia>"

            entidad = New Entidades.Polizas

            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.Pguid = guid
            entidad.Puuid = row.Cells("UUID").Value
            entidad.Preferencia = referencia
            entidad.PpolizaCONTPAQID = polizaContpaqID
            objBU.AltaPolizaCFDICompaq(entidad)

            If row.Cells("tipomovimiento").Value = "P" Then
                Dim IVA As Double = CDbl(row.Cells("IVA").Text)
                Dim cAbonos As Double = CDbl(row.Cells("TOTAL").Value)


                entidad.Pserie = row.Cells("SERIE").Value
                entidad.PnumMovimiento = movimientoCFD
                entidad.Pfecha = row.Cells("FECHA").Value
                entidad.Pfolio = row.Cells("FOLIO").Value
                entidad.Puuid = row.Cells("UUID").Value
                entidad.PpolizaID = polizaID
                entidad.PproveedorRFC = row.Cells("RFC").Value.ToString.Replace("-", "").Trim
                entidad.Psubtotal = row.Cells("SUBTOTAL").Value

                entidad.Pabonos = cAbonos
                entidad.Piva = IVA
                entidad.Preferencia = row.Cells("REFERENCIA").Value.ToString.Trim
                objBU.AltaPolizaCFDIMovimiento(entidad)
                movimientoCFD += 1

            End If
        Next

        'objBU.actualizarTotales(servidorBD, empresaBD, polizaContpaqID)

        Dim mensajeExito As New ExitoForm
        mensajeExito.mensaje = "las notas de crédito fueron replicadas satisfactoriamente."
        mensajeExito.ShowDialog()
        grdCompras.DataSource = Nothing
        LlenadoCombos()
        cmbTipo.SelectedIndex = 0
        estatus = 0
        empresa = 0
        fechaDe = New Date
        fechaA = New Date
        tipo = 0
        bloquearControles(True)
        limpiar()

    End Sub


    Public Sub guardarPolizaNotasCreditoCanceladas(ByVal tipoPoliza As Integer, ByVal conceptoPoliza As String)
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim tipoMovimiento As Integer = 0
        Dim cargos As Double = 0
        Dim abonos As Double = 0
        Dim guid As Guid
        Dim polizaID As Integer = 0
        Dim polizaContpaqID As Integer = 0
        Dim folio As String = ""
        Dim referencia As String = ""
        Dim movimientoCFD As Integer = 1
        Dim fecha As DateTime
        Dim entidad As New Entidades.Polizas
        Dim tabla As DataTable


        'INSERTA LA POLIZA
        entidad.PservidorBD = servidorBD
        entidad.PempresaBD = empresaBD
        entidad.Pejercicio = ultimafecha.Year
        entidad.Pperiodo = ultimafecha.Month

        entidad.PtipoPolizaCompaq = tipoPoliza

        entidad.Pconcepto = conceptoPoliza

        entidad.Pcargos = CDbl(lblTotalCargos2.Text)
        entidad.Pabonos = CDbl(lblTotalAbonos2.Text)
        entidad.Pfecha = ultimafecha
        entidad.PempresaID = empresaSAYContpaqSICY

        tabla = objBU.AltaPolizaCompaq(entidad)

        'RECUPERA EL ID DE LA POLIZA Y EL GUID DE CONTPAQ
        guid = tabla.Rows(0).Item("GUID")
        folio = tabla.Rows(0).Item("FOLIO")
        polizaContpaqID = tabla.Rows(0).Item("ID")

        entidad.PpolizaCONTPAQID = polizaContpaqID
        entidad.Pguid = guid
        entidad.Pfolio = folio
        entidad.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        entidad.PdiarioID = 0
        entidad.PtipoPoliza = cmbTipo.SelectedValue.ToString

        ''INSERTA POLIZA EN SAY
        tabla = objBU.AltaPolizaSAY(entidad)

        polizaID = tabla.Rows(0).Item("polizaID")

        For Each row As UltraGridRow In grdCompras.Rows

            entidad = New Entidades.Polizas
            fecha = row.Cells("FECHA").Value

            If row.Cells("TipoMovimiento").Value = "0" Then
                tipoMovimiento = 0
                cargos = row.Cells("CARGOS").Value
            Else
                tipoMovimiento = 1
                cargos = row.Cells("ABONOS").Value
            End If


            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.PcuentaContable = row.Cells("CUENTA").Value
            entidad.PpolizaID = polizaID
            entidad.Pfecha = fecha
            entidad.Pejercicio = fecha.Year
            entidad.Pperiodo = fecha.Month
            entidad.PtipoPolizaCompaq = tipoPoliza
            entidad.PnumMovimiento = row.Cells("MOVIMIENTO").Value
            entidad.PtipoMovimiento = tipoMovimiento
            entidad.Pcargos = cargos
            entidad.Preferencia = row.Cells("REFERENCIA").Value
            entidad.Pconcepto = row.Cells("Concepto").Value
            entidad.PempresaID = empresaSAYContpaqSICY
            entidad.Pfolio = folio
            entidad.PpolizaCONTPAQID = polizaContpaqID
            entidad.PdiarioID = 0

            Dim tablaGuid As DataTable
            tablaGuid = objBU.AltaPolizaMovimientoCompaq(entidad)
            guid = tablaGuid.Rows(0).Item("GUID")


            entidad.Pcargos = row.Cells("CARGOS").Value
            entidad.Pabonos = row.Cells("ABONOS").Value

            ''-----ALTA MOVIEMTNO SA-----------------------
            entidad.Puuid = row.Cells("UUID").Value
            entidad.PrutaXML = row.Cells("RutaXML").Value

            entidad.PrutaPDF = row.Cells("RutaPDF").Value
            entidad.PNotaCreditoCandelada = row.Cells("IdNotaCredito").Value
            entidad.Pconcepto = row.Cells("Concepto").Value

            entidad.PtipoPoliza = cmbTipo.SelectedValue
            entidad.PtransferenciaID = 0
            entidad.PccSAYID = row.Cells("cuentaSAYID").Value
            If row.Cells("TipoMovimiento").Value = "P" Then
                entidad.PtipoMovimiento = 1
            Else
                entidad.PtipoMovimiento = row.Cells("TipoMovimiento").Value
            End If

            entidad.Preferencia = row.Cells("REFERENCIA").Value
            objBU.AltaPolizaMovimientoSAY(entidad)


            ''INSERTA CGDI
            referencia = ""
            'If row.Cells("TipoMovimiento").Value = 1 And row.Cells("UUID").Value.ToString <> "" Then

            referencia = "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><Referencia><Documento tipo=""MovimientoPoliza"" edoPago=""0"" cadReferencia=""Movimiento de la cuenta: " + row.Cells("CUENTA").Value + ", empresa: " + empresaBD.ToString + ", guid: " + guid.ToString.ToUpper + ".""/></Referencia>"

            entidad = New Entidades.Polizas

            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.Pguid = guid
            entidad.Puuid = row.Cells("UUID").Value
            entidad.Preferencia = referencia
            entidad.PpolizaCONTPAQID = polizaContpaqID
            objBU.AltaPolizaCFDICompaq(entidad)

            If row.Cells("tipomovimiento").Value = "P" Then
                Dim IVA As Double = CDbl(row.Cells("IVA").Text)
                Dim cAbonos As Double = CDbl(row.Cells("TOTAL").Value)


                entidad.Pserie = row.Cells("SERIE").Value
                entidad.PnumMovimiento = movimientoCFD
                entidad.Pfecha = row.Cells("FECHA").Value
                entidad.Pfolio = row.Cells("FOLIO").Value
                entidad.Puuid = row.Cells("UUID").Value
                entidad.PpolizaID = polizaID
                entidad.PproveedorRFC = row.Cells("RFC").Value.ToString.Replace("-", "").Trim
                entidad.Psubtotal = row.Cells("SUBTOTAL").Value

                entidad.Pabonos = cAbonos
                entidad.Piva = IVA
                entidad.Preferencia = row.Cells("REFERENCIA").Value.ToString.Trim
                objBU.AltaPolizaCFDIMovimiento(entidad)
                movimientoCFD += 1

            End If
        Next

        'objBU.actualizarTotales(servidorBD, empresaBD, polizaContpaqID)

        Dim mensajeExito As New ExitoForm
        mensajeExito.mensaje = "las notas de crédito fueron replicadas satisfactoriamente."
        mensajeExito.ShowDialog()
        grdCompras.DataSource = Nothing
        LlenadoCombos()
        cmbTipo.SelectedIndex = 0
        estatus = 0
        empresa = 0
        fechaDe = New Date
        fechaA = New Date
        tipo = 0
        bloquearControles(True)
        limpiar()

    End Sub

    Public Sub guardarPolizaNotasCargo(ByVal tipoPoliza As Integer, ByVal conceptoPoliza As String)
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim tipoMovimiento As Integer = 0
        Dim cargos As Double = 0
        Dim abonos As Double = 0
        Dim guid As Guid
        Dim polizaID As Integer = 0
        Dim polizaContpaqID As Integer = 0
        Dim folio As String = ""
        Dim referencia As String = ""
        Dim movimientoCFD As Integer = 1
        Dim fecha As DateTime
        Dim entidad As New Entidades.Polizas
        Dim tabla As DataTable


        'INSERTA LA POLIZA
        entidad.PservidorBD = servidorBD
        entidad.PempresaBD = empresaBD
        entidad.Pejercicio = ultimafecha.Year
        entidad.Pperiodo = ultimafecha.Month
        entidad.PtipoPolizaCompaq = tipoPoliza
        entidad.Pconcepto = conceptoPoliza
        entidad.Pcargos = CDbl(lblTotalCargos2.Text)
        entidad.Pabonos = CDbl(lblTotalAbonos2.Text)
        entidad.Pfecha = ultimafecha
        entidad.PempresaID = empresaSAYContpaqSICY

        tabla = objBU.AltaPolizaCompaq(entidad)

        'RECUPERA EL ID DE LA POLIZA Y EL GUID DE CONTPAQ
        guid = tabla.Rows(0).Item("GUID")
        folio = tabla.Rows(0).Item("FOLIO")
        polizaContpaqID = tabla.Rows(0).Item("ID")
        entidad.PpolizaCONTPAQID = polizaContpaqID
        entidad.Pguid = guid
        entidad.Pfolio = folio
        entidad.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        entidad.PdiarioID = 0
        entidad.PtipoPoliza = cmbTipo.SelectedValue.ToString

        ''INSERTA POLIZA EN SAY
        tabla = objBU.AltaPolizaSAY(entidad)

        ''RECUPERA EL ID DE LA POLIZA SAY
        polizaID = tabla.Rows(0).Item("polizaID")
        entidad.PpolizaID = polizaID

        For Each row As UltraGridRow In grdCompras.Rows

            entidad = New Entidades.Polizas
            fecha = row.Cells("FECHA").Value

            If row.Cells("TipoMovimiento").Value = "0" Then
                tipoMovimiento = 0
                cargos = row.Cells("CARGOS").Value
            Else
                tipoMovimiento = 1
                cargos = row.Cells("ABONOS").Value
            End If


            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.PcuentaContable = row.Cells("CUENTA").Value
            entidad.PpolizaID = polizaID
            entidad.Pfecha = fecha
            entidad.Pejercicio = fecha.Year
            entidad.Pperiodo = fecha.Month
            entidad.PtipoPolizaCompaq = tipoPoliza
            entidad.PnumMovimiento = row.Cells("MOVIMIENTO").Value
            entidad.PtipoMovimiento = tipoMovimiento
            entidad.Pcargos = cargos
            entidad.Preferencia = row.Cells("REFERENCIA").Value
            entidad.Pconcepto = row.Cells("Concepto").Value
            entidad.PempresaID = empresaSAYContpaqSICY
            entidad.Pfolio = folio
            entidad.PpolizaCONTPAQID = polizaContpaqID
            entidad.PdiarioID = 0

            Dim tablaGuid As DataTable
            tablaGuid = objBU.AltaPolizaMovimientoCompaq(entidad)
            guid = tablaGuid.Rows(0).Item("GUID")


            entidad.Pcargos = row.Cells("CARGOS").Value
            entidad.Pabonos = row.Cells("ABONOS").Value

            ''ALTA MOVIEMTNO SAY
            entidad.Puuid = row.Cells("UUID").Value
            entidad.PrutaXML = row.Cells("RutaXML").Value

            entidad.PrutaPDF = row.Cells("RutaPDF").Value
            entidad.PNotaCargo = row.Cells("IdNotaCargo").Value
            entidad.Pconcepto = row.Cells("Concepto").Value

            entidad.PtipoPoliza = cmbTipo.SelectedValue
            entidad.PtransferenciaID = 0
            entidad.PccSAYID = row.Cells("cuentaSAYID").Value
            If row.Cells("TipoMovimiento").Value = "P" Then
                entidad.PtipoMovimiento = 1
            Else
                entidad.PtipoMovimiento = row.Cells("TipoMovimiento").Value
            End If

            entidad.Preferencia = row.Cells("REFERENCIA").Value
            objBU.AltaPolizaMovimientoSAY(entidad)


            ''INSERTA CGDI
            referencia = ""
            'If row.Cells("TipoMovimiento").Value = 1 And row.Cells("UUID").Value.ToString <> "" Then

            referencia = "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><Referencia><Documento tipo=""MovimientoPoliza"" edoPago=""0"" cadReferencia=""Movimiento de la cuenta: " + row.Cells("CUENTA").Value + ", empresa: " + empresaBD.ToString + ", guid: " + guid.ToString.ToUpper + ".""/></Referencia>"

            entidad = New Entidades.Polizas

            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.Pguid = guid
            entidad.Puuid = row.Cells("UUID").Value
            entidad.Preferencia = referencia
            entidad.PpolizaCONTPAQID = polizaContpaqID
            objBU.AltaPolizaCFDICompaq(entidad)

            If row.Cells("tipomovimiento").Value = "P" Then
                Dim IVA As Double = CDbl(row.Cells("IVA").Text)
                Dim cAbonos As Double = CDbl(row.Cells("total").Value)


                entidad.Pserie = row.Cells("SERIE").Value
                entidad.PnumMovimiento = movimientoCFD
                entidad.Pfecha = row.Cells("FECHA").Value
                entidad.Pfolio = row.Cells("FOLIO").Value
                entidad.Puuid = row.Cells("UUID").Value
                entidad.PpolizaID = polizaID
                entidad.PproveedorRFC = row.Cells("RFC").Value.ToString.Replace("-", "").Trim
                entidad.Psubtotal = row.Cells("SUBTOTAL").Value
                entidad.Piva = IVA
                entidad.Pabonos = cAbonos

                entidad.Preferencia = row.Cells("REFERENCIA").Value.ToString.Trim
                objBU.AltaPolizaCFDIMovimiento(entidad)
                movimientoCFD += 1

            End If
        Next

        'objBU.actualizarTotales(servidorBD, empresaBD, polizaContpaqID)

        Dim mensajeExito As New ExitoForm
        mensajeExito.mensaje = "La notas de cargo fueron replicadas satisfactoriamente."
        mensajeExito.ShowDialog()
        grdCompras.DataSource = Nothing
        LlenadoCombos()
        cmbTipo.SelectedIndex = 0
        estatus = 0
        empresa = 0
        fechaDe = New Date
        fechaA = New Date
        tipo = 0
        bloquearControles(True)
        limpiar()

    End Sub

    Public Sub guardarPolizaVentasCanceladas()

        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim fecha As DateTime

        Dim tipoMovimiento As Integer = 0
        Dim cargos As Double = 0
        Dim abonos As Double = 0
        Dim guid As Guid
        Dim polizaID As Integer = 0
        Dim polizaContpaqID As Integer = 0
        Dim tipoPolizaContpaqID As Integer = 0
        Dim folio As String = ""
        Dim referencia As String = ""
        Dim movimientoCFD As Integer = 1

        Dim entidad As New Entidades.Polizas
        Dim tabla As DataTable = grdCompras.DataSource

        tipoPolizaContpaqID = objBU.RecuperarCodigoTipoPolizaContpaq("Ventas", servidorBD, empresaBD)

        If tipoPolizaContpaqID > 0 Then
            'INSERTA LA POLIZA EN CONTPAQ________________________________________________
            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.Pejercicio = ultimafecha.Year
            entidad.Pperiodo = ultimafecha.Month
            entidad.PtipoPolizaCompaq = tipoPolizaContpaqID
            entidad.Pconcepto = "Ventas canceladas"
            entidad.Pcargos = CDbl(lblTotalCargos2.Text)
            entidad.Pabonos = CDbl(lblTotalAbonos2.Text)
            entidad.Pfecha = ultimafecha
            entidad.PempresaID = empresaSAYContpaqSICY

            tabla = objBU.AltaPolizaCompaq(entidad)

            'RECUPERA EL ID DE LA POLIZA Y EL GUID DE CONTPAQ____________________________
            guid = tabla.Rows(0).Item("GUID")
            folio = tabla.Rows(0).Item("FOLIO")
            polizaContpaqID = tabla.Rows(0).Item("ID")

            ''INSERTA POLIZA EN SAY______________________________________________________
            entidad.PpolizaCONTPAQID = polizaContpaqID
            entidad.Pguid = guid
            entidad.Pfolio = folio
            entidad.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.PdiarioID = 0
            entidad.PtipoPoliza = cmbTipo.SelectedValue.ToString

            tabla = objBU.AltaPolizaSAY(entidad)

            ''RECUPERA EL ID DE LA POLIZA SAY____________________________________________
            polizaID = tabla.Rows(0).Item("polizaID")
            entidad.PpolizaID = polizaID

            'INSERTA LOS MOVIMIENTOS DE POLIZA
            For Each row As UltraGridRow In grdCompras.Rows

                If Not IsDBNull(row.Cells("MOVIMIENTO").Value) Then

                    ''ALTA MOVIMJIENTO CONTPAQ________________________
                    entidad = New Entidades.Polizas

                    If IsDBNull(row.Cells("FECHA").Value) Then
                        fecha = ultimafecha
                    Else
                        fecha = row.Cells("FECHA").Value
                    End If

                    If row.Cells("TipoMovimiento").Value = 0 Then
                        tipoMovimiento = 0
                        cargos = row.Cells("CARGOS").Value
                    Else
                        tipoMovimiento = 1
                        cargos = row.Cells("ABONOS").Value
                    End If

                    If IsDBNull(row.Cells("REFERENCIA").Value) Then
                        referencia = ""
                    Else
                        referencia = row.Cells("REFERENCIA").Value
                    End If

                    entidad.PservidorBD = servidorBD
                    entidad.PempresaBD = empresaBD
                    entidad.PcuentaContable = LTrim(RTrim(row.Cells("CUENTA").Value))
                    entidad.PpolizaID = polizaID
                    entidad.Pfecha = fecha
                    entidad.Pejercicio = fecha.Year
                    entidad.Pperiodo = fecha.Month

                    entidad.PtipoPolizaCompaq = tipoPolizaContpaqID
                    entidad.PnumMovimiento = row.Cells("MOVIMIENTO").Value
                    entidad.PtipoMovimiento = tipoMovimiento
                    entidad.Pcargos = cargos

                    entidad.Preferencia = referencia
                    entidad.Pconcepto = row.Cells("Concepto").Value
                    entidad.PempresaID = empresaSAYContpaqSICY
                    entidad.Pfolio = folio
                    entidad.PpolizaCONTPAQID = polizaContpaqID
                    entidad.PdiarioID = 0
                    Dim tablaGuid As DataTable
                    tablaGuid = objBU.AltaPolizaMovimientoCompaq(entidad)
                    guid = tablaGuid.Rows(0).Item("GUID")


                    entidad.Pcargos = row.Cells("CARGOS").Value
                    entidad.Pabonos = row.Cells("ABONOS").Value

                    ''ALTA MOVIEMTNO SAY
                    If IsDBNull(row.Cells("UUID").Value) Then
                        entidad.Puuid = ""
                    Else
                        entidad.Puuid = row.Cells("UUID").Value
                    End If

                    If IsDBNull(row.Cells("RutaXML").Value) Then
                        entidad.PrutaXML = ""
                    Else
                        entidad.PrutaXML = row.Cells("RutaXML").Value
                    End If

                    If IsDBNull(row.Cells("RutaPDF").Value) Then
                        entidad.PrutaPDF = ""
                    Else
                        entidad.PrutaPDF = row.Cells("RutaPDF").Value
                    End If


                    entidad.Pconcepto = row.Cells("Concepto").Value

                    entidad.PproveedorSicyID = row.Cells("clienteID").Value
                    entidad.PtipoPoliza = cmbTipo.SelectedValue
                    entidad.PccSAYID = row.Cells("cuentaSAYID").Value
                    entidad.PcompraID = 0
                    entidad.PtransferenciaID = 0
                    entidad.pcobroid = 0
                    entidad.PventaCanceladaID = row.Cells("idVenta").Value
                    entidad.PtipoMovimiento = row.Cells("TipoMovimiento").Value
                    entidad.Preferencia = row.Cells("REFERENCIA").Value
                    objBU.AltaPolizaMovimientoSAY(entidad)

                    ''INSERTA CGDI

                    If row.Cells("TipoMovimiento").Value = 1 And row.Cells("UUID").Value.ToString <> "" Then

                        referencia = "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><Referencia><Documento tipo=""MovimientoPoliza"" edoPago=""0"" cadReferencia=""Movimiento de la cuenta: " + row.Cells("CUENTA").Value + ", empresa: " + empresaBD.ToString + ", guid: " + guid.ToString.ToUpper + ".""/></Referencia>"

                        entidad = New Entidades.Polizas

                        entidad.PservidorBD = servidorBD
                        entidad.PempresaBD = empresaBD
                        entidad.Pguid = guid
                        entidad.Puuid = row.Cells("UUID").Value
                        entidad.Preferencia = referencia
                        entidad.PpolizaCONTPAQID = polizaContpaqID
                        objBU.AltaPolizaCFDICompaq(entidad)


                        ''INSERTA MOVIMIENTO CFDI

                        If IsDBNull(row.Cells("SERIE").Value) Then
                            entidad.Pserie = "''"
                        Else
                            entidad.Pserie = row.Cells("SERIE").Value
                        End If
                        entidad.PnumMovimiento = movimientoCFD
                        entidad.Pfecha = row.Cells("FECHA").Value
                        entidad.Pfolio = row.Cells("FOLIO").Value
                        entidad.Puuid = row.Cells("UUID").Value
                        entidad.PpolizaID = polizaID
                        entidad.PproveedorRFC = row.Cells("RFC").Value.ToString.Replace("-", "").Trim
                        entidad.Psubtotal = row.Cells("SUBTOTAL").Value

                        If row.Cells("abonos").Value = 0 Then
                            entidad.Pabonos = row.Cells("cargos").Value
                        Else
                            entidad.Pabonos = row.Cells("ABONOS").Value
                        End If

                        entidad.Piva = row.Cells("IVA").Value
                        entidad.Preferencia = row.Cells("REFERENCIA").Value.ToString.Trim
                        objBU.AltaPolizaCFDIMovimiento(entidad)
                        movimientoCFD += 1

                    End If
                End If
            Next

            ''objBU.actualizarTotales(servidorBD, empresaBD, polizaContpaqID)

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Las ventas fueron replicadas satisfactoriamente."
            mensajeExito.ShowDialog()
            grdCompras.DataSource = Nothing
            LlenadoCombos()
            cmbTipo.SelectedIndex = 0
            estatus = 0
            empresa = 0
            fechaDe = New Date
            fechaA = New Date
            tipo = 0
            bloquearControles(True)
            limpiar()
        Else
            Dim objAdvertencia As New AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "No se encontro el tipo de poliza de 'Ventas' en la base de datos de Contpaq"
            objAdvertencia.ShowDialog()

        End If

    End Sub

    Public Sub guardarPolizaChequesPosfechados()

        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim fecha As DateTime

        Dim tipoMovimiento As Integer = 0
        Dim cargos As Double = 0
        Dim abonos As Double = 0
        Dim guid As Guid
        Dim polizaID As Integer = 0
        Dim polizaContpaqID As Integer = 0
        Dim tipoPolizaContpaqID As Integer = 0
        Dim folio As String = ""
        Dim referencia As String = ""
        Dim movimientoCFD As Integer = 1

        Dim entidad As New Entidades.Polizas
        Dim tabla As DataTable = grdCompras.DataSource

        tipoPolizaContpaqID = objBU.RecuperarCodigoTipoPolizaContpaq("Documentos por cobrar", servidorBD, empresaBD)

        If tipoPolizaContpaqID > 0 Then
            'INSERTA LA POLIZA
            entidad.PservidorBD = servidorBD
            entidad.PempresaBD = empresaBD
            entidad.Pejercicio = ultimafecha.Year
            entidad.Pperiodo = ultimafecha.Month
            entidad.PtipoPolizaCompaq = tipoPolizaContpaqID
            entidad.Pconcepto = "Cobros con Cheques posfechados"
            entidad.Pcargos = CDbl(lblTotalCargos2.Text)
            entidad.Pabonos = CDbl(lblTotalAbonos2.Text)
            entidad.Pfecha = ultimafecha
            entidad.PempresaID = empresaSAYContpaqSICY

            tabla = objBU.AltaPolizaCompaq(entidad)

            'RECUPERA EL ID DE LA POLIZA Y EL GUID DE CONTPAQ
            guid = tabla.Rows(0).Item("GUID")
            folio = tabla.Rows(0).Item("FOLIO")
            polizaContpaqID = tabla.Rows(0).Item("ID")
            entidad.PpolizaCONTPAQID = polizaContpaqID
            entidad.Pguid = guid
            entidad.Pfolio = folio
            entidad.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.PdiarioID = 0
            entidad.PtipoPoliza = cmbTipo.SelectedValue.ToString

            ''INSERTA POLIZA EN SAY
            tabla = objBU.AltaPolizaSAY(entidad)

            ''RECUPERA EL ID DE LA POLIZA SAY
            polizaID = tabla.Rows(0).Item("polizaID")
            entidad.PpolizaID = polizaID

            'INSERTA LOS MOVIMIENTOS DE POLIZA
            For Each row As UltraGridRow In grdCompras.Rows

                If Not IsDBNull(row.Cells("MOVIMIENTO").Value) Then

                    entidad = New Entidades.Polizas

                    If IsDBNull(row.Cells("FECHA").Value) Then
                        fecha = ultimafecha
                    Else
                        fecha = row.Cells("FECHA").Value
                    End If

                    If row.Cells("TipoMovimiento").Value = 0 Then
                        tipoMovimiento = 0
                        cargos = row.Cells("CARGOS").Value
                    Else
                        tipoMovimiento = 1
                        cargos = row.Cells("ABONOS").Value
                    End If

                    If IsDBNull(row.Cells("REFERENCIA").Value) Then
                        referencia = ""
                    Else
                        referencia = row.Cells("REFERENCIA").Value
                    End If

                    entidad.PservidorBD = servidorBD
                    entidad.PempresaBD = empresaBD
                    entidad.PcuentaContable = LTrim(RTrim(row.Cells("CUENTA").Value))
                    entidad.PpolizaID = polizaID
                    entidad.Pfecha = fecha
                    entidad.Pejercicio = fecha.Year
                    entidad.Pperiodo = fecha.Month

                    entidad.PtipoPolizaCompaq = tipoPolizaContpaqID
                    entidad.PnumMovimiento = row.Cells("MOVIMIENTO").Value
                    entidad.PtipoMovimiento = tipoMovimiento
                    entidad.Pcargos = cargos

                    entidad.Preferencia = referencia
                    entidad.Pconcepto = row.Cells("Concepto").Value
                    entidad.PempresaID = empresaSAYContpaqSICY
                    entidad.Pfolio = folio
                    entidad.PpolizaCONTPAQID = polizaContpaqID
                    entidad.PdiarioID = 0
                    Dim tablaGuid As DataTable
                    tablaGuid = objBU.AltaPolizaMovimientoCompaq(entidad)
                    guid = tablaGuid.Rows(0).Item("GUID")


                    entidad.Pcargos = row.Cells("CARGOS").Value
                    entidad.Pabonos = row.Cells("ABONOS").Value

                    ''ALTA MOVIEMTNO SAY
                    If IsDBNull(row.Cells("UUID").Value) Then
                        entidad.Puuid = ""
                    Else
                        entidad.Puuid = row.Cells("UUID").Value
                    End If

                    If IsDBNull(row.Cells("RutaXML").Value) Then
                        entidad.PrutaXML = ""
                    Else
                        entidad.PrutaXML = row.Cells("RutaXML").Value
                    End If

                    If IsDBNull(row.Cells("RutaPDF").Value) Then
                        entidad.PrutaPDF = ""
                    Else
                        entidad.PrutaPDF = row.Cells("RutaPDF").Value
                    End If

                    entidad.Pconcepto = row.Cells("Concepto").Value

                    entidad.PproveedorSicyID = row.Cells("clienteID").Value
                    entidad.PtipoPoliza = cmbTipo.SelectedValue
                    entidad.PccSAYID = row.Cells("cuentaSAYID").Value
                    entidad.PcompraID = 0
                    entidad.PtransferenciaID = 0
                    entidad.pcobroid = 0
                    entidad.PIdChequeDepositoInterno = 0
                    entidad.PIdChequeDevuelto = 0
                    entidad.PIdChequeDepositoDevuelto = 0
                    entidad.PIdChequePosfechado = row.Cells("IdCheque").Value
                    entidad.PtipoMovimiento = row.Cells("TipoMovimiento").Value
                    entidad.Preferencia = row.Cells("REFERENCIA").Value
                    objBU.AltaPolizaMovimientoSAY(entidad)

                    ''INSERTA CGDI
                    referencia = ""
                    If row.Cells("TipoMovimiento").Value = 1 And row.Cells("UUID").Value.ToString <> "" Then

                        referencia = "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><Referencia><Documento tipo=""MovimientoPoliza"" edoPago=""0"" cadReferencia=""Movimiento de la cuenta: " + row.Cells("CUENTA").Value + ", empresa: " + empresaBD.ToString + ", guid: " + guid.ToString.ToUpper + ".""/></Referencia>"

                        entidad = New Entidades.Polizas

                        entidad.PservidorBD = servidorBD
                        entidad.PempresaBD = empresaBD
                        entidad.Pguid = guid
                        entidad.Puuid = row.Cells("UUID").Value
                        entidad.Preferencia = referencia
                        entidad.PpolizaCONTPAQID = polizaContpaqID
                        objBU.AltaPolizaCFDICompaq(entidad)


                        ''INSERTA MOVIMIENTO CFDI

                        If IsDBNull(row.Cells("SERIE").Value) Then
                            entidad.Pserie = "''"
                        Else
                            entidad.Pserie = row.Cells("SERIE").Value
                        End If
                        entidad.PnumMovimiento = movimientoCFD
                        entidad.Pfecha = row.Cells("FECHA").Value
                        entidad.Pfolio = row.Cells("FOLIO").Value
                        entidad.Puuid = row.Cells("UUID").Value
                        entidad.PpolizaID = polizaID
                        entidad.PproveedorRFC = row.Cells("RFC").Value.ToString.Replace("-", "").Trim
                        entidad.Psubtotal = row.Cells("SubtotalAbono").Value

                        If row.Cells("abonos").Value = 0 Then
                            entidad.Pabonos = row.Cells("cargos").Value
                        Else
                            entidad.Pabonos = row.Cells("ABONOS").Value
                        End If

                        entidad.Piva = row.Cells("IVA_Abono").Value
                        entidad.Preferencia = row.Cells("REFERENCIA").Value.ToString.Trim
                        objBU.AltaPolizaCFDIMovimiento(entidad)
                        movimientoCFD += 1

                    End If
                End If
            Next

            objBU.actualizarTotales(servidorBD, empresaBD, polizaContpaqID)

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Los cheques posfechados fueron replicados satisfactoriamente."
            mensajeExito.ShowDialog()
            grdCompras.DataSource = Nothing
            LlenadoCombos()
            cmbTipo.SelectedIndex = 0
            estatus = 0
            empresa = 0
            fechaDe = New Date
            fechaA = New Date
            tipo = 0
            bloquearControles(True)
            limpiar()
        Else
            Dim objAdvertencia As New AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "No se encontro el tipo de poliza de 'Documentos por cobrar' en la base de datos de Contpaq"
            objAdvertencia.ShowDialog()

        End If

    End Sub

#End Region

#Region "Metodos Cargar Cuentas"

    Public Sub llenarCuentasClientes(ByVal row As DataRow)
        Dim cuentaContable As String = ""
        Dim clienteDesc As String = ""
        Dim clienteIDSicy As String = ""
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        clienteDesc = row.Item("Cliente")
        clienteIDSicy = row.Item("Clienteid")
        tabla = Nothing

        tabla = objBU.validarclienteExisteSay(clienteIDSicy)

        If tabla.Rows.Count > 0 Then
            tabla = Nothing
            tabla = objBU.cargarCuentaContableSayClienteNueva(empresaSAYContpaqSICY, clienteIDSicy)
            If tabla.Rows.Count = 0 Then
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.Salmon
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 0
                btnEnvioContp.Enabled = False
            Else
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = tabla.Rows(0).Item("cuentaSAYID").ToString
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = tabla.Rows(0).Item("CuentaContableSAY").ToString
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1

                If cmbTipo.Text = "NOTAS DE CRÉDITO" Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = tabla.Rows(0).Item("Descripcion").ToString
                ElseIf cmbTipo.Text = "NOTAS DE CARGO" Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = tabla.Rows(0).Item("Descripcion").ToString
                ElseIf cmbTipo.Text = "CHEQUES POSFECHADOS" Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = tabla.Rows(0).Item("Descripcion").ToString
                ElseIf cmbTipo.Text = "DEPÓSITOS IDENTIFICADOS" Then
                    If grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("Cargos").Value > 0 Then
                        grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("Concepto").Value = tabla.Rows(0).Item("Descripcion").ToString
                    End If

                End If

            End If
        Else
            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = ""
            grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.SandyBrown
            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 2
            btnEnvioContp.Enabled = False
        End If
    End Sub

    Public Sub llenarCuentasClientesOptimizado(ByVal row As DataRow)
        Dim cuentaContable As String = ""
        Dim clienteDesc As String = ""
        Dim clienteIDSicy As String = ""
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim renglon As DataRow = Nothing
        Dim renglon2 As DataRow = Nothing
        clienteDesc = row.Item("Cliente")
        clienteIDSicy = row.Item("Clienteid")

        renglon = tablaProveedores.Rows.Find(clienteIDSicy)

        If renglon Is Nothing Then
            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = ""
            grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.SandyBrown
            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 2
            btnEnvioContp.Enabled = False
        Else
            For Each row1 As DataRow In tablaProv.Rows
                If row1.Item(3) = clienteIDSicy Then
                    renglon2 = row1
                    Exit For
                End If
            Next

            If renglon2 Is Nothing Then
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.Salmon
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 0
                btnEnvioContp.Enabled = False
            Else
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = renglon2.Item("cuentaSAYID").ToString
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = renglon2.Item("CuentaContableSAY").ToString
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1

                If cmbTipo.Text = "NOTAS DE CRÉDITO" Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = renglon2.Item("Descripcion").ToString
                ElseIf cmbTipo.Text = "NOTAS DE CARGO" Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = renglon2.Item("Descripcion").ToString
                ElseIf cmbTipo.Text = "CHEQUES POSFECHADOS" Then
                    grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("Nombre de la cuenta").Value = renglon2.Item("Descripcion").ToString
                ElseIf cmbTipo.Text = "DEPÓSITOS IDENTIFICADOS" Then
                    If grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("Cargos").Value > 0 Then
                        grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("Concepto").Value = renglon2.Item("Descripcion").ToString
                    End If

                End If
            End If
        End If
    End Sub

    Public Sub llenarCuentasProveedores(ByVal row As DataRow)
        Dim cuentaContable As String = ""
        Dim proveedorDesc As String = ""
        Dim proveedorIDSicy As String = ""
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        Dim proveedorRFC As String

        proveedorRFC = row.Item("RFC").ToString.Replace("-", "").Replace(" ", "").Trim
        tabla = objBU.ValidarPersonaProveedorExisteContpaq(proveedorRFC, servidorBD, empresaBD)

        If tabla.Rows.Count() > 0 Then
            proveedorDesc = row.Item("PROVEEDOR")
            proveedorIDSicy = row.Item("proveedorSicyID")

            tabla = Nothing
            tabla = objBU.cargarCuentaContableSayProveedorNueva(empresaSAYContpaqSICY, proveedorIDSicy)

            If tabla.Rows.Count() > 0 Then
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = tabla.Rows(0).Item("CuentaContableSAY").ToString
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = tabla.Rows(0).Item("cuentaSAYID").ToString
                If cmbTipo.Text = "COMPRAS" Then
                    grdCompras.Rows(grdCompras.Rows.Count - 3).Cells("Concepto").Value = tabla.Rows(0).Item("Descripcion").ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("Concepto").Value = tabla.Rows(0).Item("Descripcion").ToString
                End If
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
            Else
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.Salmon
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 0
                btnEnvioContp.Enabled = False
            End If
        Else
            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = ""
            grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.SandyBrown
            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 0
            btnEnvioContp.Enabled = False
        End If
    End Sub

    Public Sub llenarCuentasProveedoresOptimizado(ByVal row As DataRow)
        Dim cuentaContable As String = ""
        Dim proveedorDesc As String = ""
        Dim proveedorIDSicy As String = ""
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim renglon, renglon2 As DataRow
        Dim proveedorRFC, cad As String
        Dim existe As Boolean = False

        proveedorRFC = row.Item("RFC").ToString.Replace("-", "").Replace(" ", "").Trim
        renglon = tablaProveedores.Rows.Find(proveedorRFC)

        If renglon Is Nothing Then
            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = ""
            grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.SandyBrown
            grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 0
            btnEnvioContp.Enabled = False
        Else
            proveedorDesc = row.Item("PROVEEDOR")
            proveedorIDSicy = row.Item("proveedorSicyID")
            renglon2 = Nothing

            For Each row1 As DataRow In tablaProv.Rows
                cad = row1.Item(3).ToString & row1.Item(1).ToString
                If row1.Item(3) = proveedorIDSicy Then
                    renglon2 = row1
                    Exit For
                End If
            Next

            If renglon2 Is Nothing Then
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = ""
                grdCompras.Rows(grdCompras.Rows.Count - 1).Appearance.BackColor = Drawing.Color.Salmon
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 0
                btnEnvioContp.Enabled = False
            Else
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("CUENTA").Value = renglon2.Item("CuentaContableSAY").ToString
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("cuentaSAYID").Value = renglon2.Item("cuentaSAYID").ToString
                If cmbTipo.Text = "COMPRAS" Then
                    grdCompras.Rows(grdCompras.Rows.Count - 3).Cells("Concepto").Value = renglon2.Item("Descripcion").ToString
                    grdCompras.Rows(grdCompras.Rows.Count - 2).Cells("Concepto").Value = renglon2.Item("Descripcion").ToString
                End If
                grdCompras.Rows(grdCompras.Rows.Count - 1).Cells("bandera").Value = 1
            End If
        End If
    End Sub



#End Region

#Region "Metodos"

    Public Sub LlenadoCombos()

        Dim altpoliBU As New Negocios.AltaPolizaBU
        Dim cbempresasContpaq As New DataTable
        Dim cbtipoPoliza As New DataTable
        'Cargamos combos
        cbempresasContpaq = altpoliBU.CargaEmpresaCONTPAQ(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString)
        cbempresasContpaq.Rows.InsertAt(cbempresasContpaq.NewRow(), 0)
        cmbEmpresa.DataSource = cbempresasContpaq

        cmbEmpresa.ValueMember = "essc_sayid"
        cmbEmpresa.DisplayMember = "RazonSocial"

        cbtipoPoliza = altpoliBU.CargaTiposPoliza()
        cbtipoPoliza.Rows.InsertAt(cbtipoPoliza.NewRow(), 0)
        cmbTipo.DataSource = cbtipoPoliza
        cmbTipo.ValueMember = "poti_polizaTipoId"
        cmbTipo.DisplayMember = "poti_nombre"

        dtpDe.Value = Now.Date
        dtpAl.Value = Now.Date

        cmbEstatus.SelectedIndex = 1
    End Sub

    Public Sub limpiar()
        grdCompras.DataSource = Nothing
        LlenadoCombos()
        cmbTipo.SelectedIndex = 0
        estatus = 0
        empresa = 0
        fechaDe = New Date
        fechaA = New Date
        tipo = 0
        lblTotalAbonos2.Text = 0
        lblTotalCargos2.Text = 0
    End Sub

    Public Sub disenoGrid()

        If grdCompras.Rows.Count > 0 Then

            grdCompras.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            Try
                grdCompras.DisplayLayout.Bands(0).Columns("MOVIMIENTO").CellAppearance.TextHAlign = HAlign.Right
                grdCompras.DisplayLayout.Bands(0).Columns("MOVIMIENTO").Width = 20
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("CUENTA").CellAppearance.TextHAlign = HAlign.Right
                grdCompras.DisplayLayout.Bands(0).Columns("CUENTA").Width = 70
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("PROVEEDOR").CellAppearance.TextHAlign = HAlign.Left
            Catch ex As Exception
            End Try


            Try
                grdCompras.DisplayLayout.Bands(0).Columns("Cliente").CellAppearance.TextHAlign = HAlign.Left
            Catch ex As Exception
            End Try


            Try
                grdCompras.DisplayLayout.Bands(0).Columns("Concepto").CellAppearance.TextHAlign = HAlign.Left
            Catch ex As Exception
            End Try


            Try
                grdCompras.DisplayLayout.Bands(0).Columns("CARGOS").CellAppearance.TextHAlign = HAlign.Right
                grdCompras.DisplayLayout.Bands(0).Columns("CARGOS").Format = "n2"
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("ABONOS").CellAppearance.TextHAlign = HAlign.Right
                grdCompras.DisplayLayout.Bands(0).Columns("ABONOS").Format = "n2"
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("FECHA").CellAppearance.TextHAlign = HAlign.Right
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("ClabeInterbancaria").CellAppearance.TextHAlign = HAlign.Right
            Catch ex As Exception
            End Try


            Try
                grdCompras.DisplayLayout.Bands(0).Columns("REFERENCIA").CellAppearance.TextHAlign = HAlign.Left
            Catch ex As Exception
            End Try


            Try
                grdCompras.DisplayLayout.Bands(0).Columns("NumAutorizacion").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("idTransferencia").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("proveedorSicyID").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("TipoCompra").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("IVA").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("SUBTOTAL").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("IdNotaCargo").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("IdNotaCredito").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("CuentaNotaCredito").Hidden = True
            Catch ex As Exception
            End Try
            Try
                grdCompras.DisplayLayout.Bands(0).Columns("TOTAL").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("NAVE").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("RutaXML").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("RutaPDF").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("compraSICYID").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("TipoMovimiento").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("uuid").Hidden = True
            Catch ex As Exception
            End Try


            Try
                grdCompras.DisplayLayout.Bands(0).Columns("FOLIO").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("SERIE").Hidden = True
            Catch ex As Exception
            End Try
            Try
                grdCompras.DisplayLayout.Bands(0).Columns("Concepto_NotaCredito").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("ImporteTransferencia").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("RFC").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("RazonSocialP").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("CUENTAID").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("MOVIMIENTOID").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("CuentaBancaria").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("bandera").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("RespaldoColor").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("PolizaSAYID").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("PolizaContpaqID").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("bancoContpaqid").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("cuentaContpaqID").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("clabeInterbancaria").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("Clienteid").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("cobroid").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("xml").Hidden = True
            Catch ex As Exception
            End Try
            Try
                grdCompras.DisplayLayout.Bands(0).Columns("pdf").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("cuentaSAYID").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("idVenta").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("depositoID").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("tipoPolizaContpaqID").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("cuentaMaterial").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("DescripcionCuentaMaterial").Hidden = True
            Catch ex As Exception
            End Try
            Try
                grdCompras.DisplayLayout.Bands(0).Columns("FACTURA").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("TipoCliente").CellAppearance.TextHAlign = HAlign.Left
            Catch ex As Exception
            End Try


            Try
                grdCompras.DisplayLayout.Bands(0).Columns("descripcionCuenta").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("descripcionCuenta").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("TotalVenta_?").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("Cheque").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("FechaVence").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("SubtotalAbono").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("IVA_Abono").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("IdCheque").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("RemisionID").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("DoctosVentas").Hidden = True
            Catch ex As Exception
            End Try

            Try
                grdCompras.DisplayLayout.Bands(0).Columns("clienteid").Hidden = True
                grdCompras.DisplayLayout.Bands(0).Columns("clienteid1").Hidden = True
                grdCompras.DisplayLayout.Bands(0).Columns("idnotacredito").Hidden = True
                grdCompras.DisplayLayout.Bands(0).Columns("cuentanotacredito").Hidden = True
            Catch ex As Exception
            End Try


            'FechaDeposito, depositoID

            grdCompras.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            grdCompras.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdCompras.DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.CopyWithHeaders
            grdCompras.DisplayLayout.Bands(0).Columns("Fecha").CellActivation = Activation.NoEdit


            grdCompras.DisplayLayout.MaxRowScrollRegions = 1

            Dim width As Integer
            For Each col As UltraGridColumn In grdCompras.Rows.Band.Columns
                If Not col.Hidden Then
                    width += col.Width
                End If
            Next

            If width > grdCompras.Width Then
                grdCompras.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            Else
                grdCompras.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            End If
        End If
    End Sub

    Public Function extraerUUID(ByVal Ruta As String) As Entidades.Polizas

        Dim lista As New Entidades.Polizas
        If Ruta = "" Then
            Ruta = "NO TIENE XML RELACIONADO"
        End If
        Try
            Dim reader As XmlTextReader = New XmlTextReader(Ruta)

            lista.Puuid = ""
            lista.Pserie = ""
            lista.Pfolio = ""


            Do While (reader.Read())

                Select Case reader.NodeType


                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.                    
                        If reader.HasAttributes Then 'If attributes exist
                            While reader.MoveToNextAttribute()
                                If reader.Name.ToString.ToUpper = "UUID" Then
                                    lista.Puuid = reader.Value
                                End If
                                Dim nombre = reader.Name.ToString.ToUpper.Trim
                                If nombre = "SERIE" Then
                                    lista.Pserie = reader.Value
                                End If

                                If reader.Name = "folio" Or reader.Name = "Folio" Then
                                    lista.Pfolio = reader.Value
                                End If

                                If reader.Name.ToString.ToUpper = "RFC" Then
                                    ' MsgBox(reader.Value)
                                End If

                            End While
                        End If
                End Select



            Loop

            Return lista
            reader.Close()
        Catch ex As Exception
            Dim objadvertencia As New AdvertenciaForm
            objadvertencia.StartPosition = FormStartPosition.CenterScreen
            objadvertencia.mensaje = " ERROR AL LEER EL XML" + vbNewLine + " (" + Ruta.ToString + ")"
            objadvertencia.ShowDialog()
            ''MsgBox(" ERROR AL LEER EL XML" + vbNewLine + " (" + Ruta.ToString + ")")
            lista.Puuid = " ERROR AL LEER XML"
            lista.Pserie = " ERROR AL LEER XML"
            lista.Pfolio = " ERROR AL LEER XML"
            btnEnvioContp.Enabled = False

            lista.PrutaXML = Ruta

            Return lista
        End Try

    End Function

    Public Function validarFechas() As Boolean
        Dim mesInicio As Integer = 0
        Dim mesFin As Integer = 0
        Dim fechaInicio As DateTime
        Dim fechaFin As DateTime
        Dim estaMal As Boolean

        fechaInicio = dtpDe.Value
        fechaFin = dtpAl.Value
        mesInicio = fechaInicio.Month
        mesFin = fechaFin.Month

        If mesInicio <> mesFin Then
            Dim objMesj As New Tools.AdvertenciaForm
            estaMal = True
            objMesj.mensaje = "El rango de fechas tiene que estar dentro del mismo mes."
            objMesj.ShowDialog()

        End If
        Return estaMal
    End Function

    Public Sub bloquearControles(ByVal boleano As Boolean)
        cmbEmpresa.Enabled = boleano
        cmbEstatus.Enabled = boleano
        cmbTipo.Enabled = boleano
        dtpDe.Enabled = boleano
        dtpAl.Enabled = boleano
        btnMostrar.Enabled = boleano
    End Sub

    Public Function validarDatos() As Boolean
        Dim contador As Integer = 0

        If (cmbEmpresa.SelectedIndex.Equals(0)) Then
            lblEmpresa.ForeColor = Drawing.Color.Red
            contador += 1
        Else
            empresa = cmbEmpresa.SelectedValue
            lblEmpresa.ForeColor = Drawing.Color.Black
        End If

        If cmbTipo.SelectedIndex <= 0 Then
            lblTipo.ForeColor = Drawing.Color.Red
            contador += 1
        Else
            tipo = cmbTipo.SelectedValue
            lblTipo.ForeColor = Drawing.Color.Black
        End If
        If contador > 0 Then
            estamal = True
        Else
            estamal = False
        End If

        Return estamal
    End Function



#End Region

#Region "Eventos de Controles"

    'Private Sub dtpDe_ValueChanged(sender As Object, e As EventArgs) Handles dtpDe.ValueChanged
    '    If cmbTipo.Text = "TRANSFERENCIAS" Or cmbTipo.Text = "DEPÓSITOS POR IDENTIFICAR" Or cmbTipo.Text = "NOTAS DE CRÉDITO" Or cmbTipo.Text = "NOTAS DE CARGO" Then
    '        dtpAl.Value = dtpDe.Value
    '    End If
    'End Sub

    'Private Sub dtpAl_ValueChanged(sender As Object, e As EventArgs) Handles dtpAl.ValueChanged
    '    If cmbTipo.Text = "TRANSFERENCIAS" Or cmbTipo.Text = "DEPÓSITOS POR IDENTIFICAR" Or cmbTipo.Text = "NOTAS DE CRÉDITO" Then
    '        dtpDe.Value = dtpAl.Value
    '    End If
    'End Sub

    Private Sub cmbTipo_DropDownClosed(sender As Object, e As EventArgs) Handles cmbTipo.DropDownClosed
        If cmbTipo.Text = "TRANSFERENCIAS" Or cmbTipo.Text = "DEPÓSITOS POR IDENTIFICAR" Then
            dtpAl.Value = dtpDe.Value
        End If
    End Sub

    Private Sub grdCompras_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdCompras.DoubleClickRow
        'Bandera 0 no tiene cuenta contable
        If e.Row.Cells("BANDERA").Value.ToString = "0" Then
            Dim obj As New RelacionCuentasContablesForm
            Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
            Dim tabla As New DataTable
            Dim contpacID As Integer = 0
            Dim cuentaSAYID As Integer = 0
            Dim cuenta As String = ""
            Dim cuentaDesc As String = ""
            Dim proveedorID As String = ""
            Dim proveedorDesc As String = ""
            Dim proveedorClienteRFC As String = ""
            If cmbTipo.Text = "COMPRAS" Or cmbTipo.Text = "TRANSFERENCIAS" Or cmbTipo.Text = "GASTOS" Or cmbTipo.Text = "GASTOS Y COMPRAS" Or cmbTipo.Text = "PRODUCTO TERMINADO" Or cmbTipo.Text = "GASTO DE TRANSPORTE" Or cmbTipo.Text = "ACTIVO FIJO" Then
                tabla = objBu.cargarCuentasContablesContpaqRelacion(empresaSAYContpaqSICY, 7, "201", "205", servidorBD, empresaBD)
                proveedorID = e.Row.Cells("proveedorSicyID").Value
                proveedorDesc = e.Row.Cells("proveedor").Value
                proveedorClienteRFC = e.Row.Cells("RFC").Value.ToString.Replace("-", "").Replace(" ", "").Trim
                With obj
                    .tipoCuenta = cmbTipo.Text
                    .proveedorClienteID = proveedorID
                    .proveedorDesc = proveedorDesc
                    .empresaSAYContpaqSICY = empresaSAYContpaqSICY
                    .servidorBD = servidorBD
                    .empresaBD = empresaBD
                    .proveedorClienteRFC = proveedorClienteRFC
                    .tablaCuentas = tabla
                    .ShowDialog()
                    cuenta = .cuentaContpaq
                    cuentaDesc = .cuentaDescripcion
                    cuentaSAYID = .cuentaSAYID
                End With

                If Not IsNothing(cuenta) Then
                    btnEnvioContp.Enabled = True
                    For Each Row As UltraGridRow In grdCompras.Rows
                        If Row.Cells("proveedor").Value = proveedorDesc Then
                            Row.Cells("Cuenta").Value = cuenta
                            Row.Cells("cuentaSAYID").Value = cuentaSAYID

                            If cmbTipo.Text = "COMPRAS" Then
                                grdCompras.Rows(Row.Index - 1).Cells("Concepto").Value = cuentaDesc
                                grdCompras.Rows(Row.Index - 2).Cells("Concepto").Value = cuentaDesc
                                '                                Row.Cells("Concepto").Value = cuentaDesc
                            End If
                            Row.Cells("Bandera").Value = 1
                            If Row.Cells("RespaldoColor").Value = "LightSteelBlue" Then
                                grdCompras.Rows(Row.Index).Appearance.BackColor = Drawing.Color.LightSteelBlue
                            Else
                                grdCompras.Rows(Row.Index).Appearance.BackColor = Drawing.Color.White
                            End If



                        ElseIf cmbTipo.Text = "TRANSFERENCIAS" And Row.Index > 0 Then
                            If grdCompras.Rows(Row.Index - 1).Cells("Cuenta").Value = cuenta Then
                                grdCompras.Rows(Row.Index + 1).Cells("Concepto").Value = cuentaDesc
                                grdCompras.Rows(Row.Index + 2).Cells("Concepto").Value = cuentaDesc
                            End If
                        ElseIf (cmbTipo.Text = "GASTOS" Or cmbTipo.Text = "GASTOS Y COMPRAS" Or cmbTipo.Text = "PRODUCTO TERMINADO" Or cmbTipo.Text = "GASTO DE TRANSPORTE") Then
                            If Row.Cells("CARGOS").Value > 0 Then
                                Row.Cells("Concepto").Value = cuentaDesc
                            End If

                        End If

                        If Row.Cells("cuenta").Value = "" Or (lblTotalAbonos2.Text <> lblTotalCargos2.Text) Then
                            btnEnvioContp.Enabled = False
                        End If

                    Next
                End If


            ElseIf cmbTipo.Text = "DEPÓSITOS IDENTIFICADOS" Or cmbTipo.Text = "DEPÓSITOS POR IDENTIFICAR" Or cmbTipo.Text = "VENTAS" Or cmbTipo.Text = "NOTAS DE CRÉDITO" Then
                tabla = objBu.cargarCuentasContablesContpaqRelacion(empresaSAYContpaqSICY, 3, "105", "105", servidorBD, empresaBD)
                proveedorID = e.Row.Cells("clienteID").Value
                proveedorDesc = e.Row.Cells("cliente").Value
                With obj
                    .tipoCuenta = cmbTipo.Text
                    .proveedorClienteID = proveedorID
                    .proveedorDesc = proveedorDesc
                    .proveedorClienteRFC = e.Row.Cells("RFC").Value.ToString.Replace("-", "").Replace(" ", "").Trim
                    .empresaSAYContpaqSICY = empresaSAYContpaqSICY
                    .servidorBD = servidorBD
                    .empresaBD = empresaBD
                    .tablaCuentas = tabla
                    .btnAlta.Enabled = False
                    .ShowDialog()
                    cuenta = .cuentaContpaq
                    cuentaDesc = .cuentaDescripcion
                    cuentaSAYID = .cuentaSAYID
                End With

                If Not IsNothing(cuenta) Then
                    btnEnvioContp.Enabled = True
                    For Each Row As UltraGridRow In grdCompras.Rows
                        If cmbTipo.Text = "NOTAS DE CRÉDITO" Then
                            If Row.Cells("clienteID").Value = proveedorID And (Row.Cells("tipomovimiento").Value = "1" Or Row.Cells("tipomovimiento").Value = "P") Then
                                Row.Cells("Cuenta").Value = cuenta
                                Row.Cells("cuentaSAYID").Value = cuentaSAYID

                                If cmbTipo.Text = "DEPÓSITOS POR IDENTIFICAR" Then

                                    grdCompras.Rows(Row.Index - 1).Cells("Concepto").Value = cuentaDesc
                                    Row.Cells("Bandera").Value = 1
                                ElseIf cmbTipo.Text = "VENTAS" Then
                                    grdCompras.Rows(Row.Index + 1).Cells("Concepto").Value = cuentaDesc
                                    grdCompras.Rows(Row.Index + 2).Cells("Concepto").Value = cuentaDesc
                                ElseIf cmbTipo.Text = "DEPÓSITOS IDENTIFICADOS" Then
                                    If grdCompras.Rows(Row.Index - 1).Cells("Cargos").Value > 0 Then
                                        grdCompras.Rows(Row.Index - 1).Cells("Concepto").Value = cuentaDesc
                                    End If
                                    Row.Cells("Bandera").Value = 1
                                End If

                                If Row.Cells("RespaldoColor").Value = "LightSteelBlue" Then
                                    grdCompras.Rows(Row.Index).Appearance.BackColor = Drawing.Color.LightSteelBlue
                                Else
                                    grdCompras.Rows(Row.Index).Appearance.BackColor = Drawing.Color.White
                                End If
                            End If
                            If Row.Cells("cuenta").Value = "" Or lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                                btnEnvioContp.Enabled = False
                            End If
                        Else
                            If Row.Cells("cliente").Value = proveedorDesc Then
                                Row.Cells("Cuenta").Value = cuenta
                                Row.Cells("cuentaSAYID").Value = cuentaSAYID

                                If cmbTipo.Text = "DEPÓSITOS POR IDENTIFICAR" Then

                                    grdCompras.Rows(Row.Index - 1).Cells("Concepto").Value = cuentaDesc
                                    Row.Cells("Bandera").Value = 1
                                ElseIf cmbTipo.Text = "VENTAS" Then
                                    grdCompras.Rows(Row.Index + 1).Cells("Concepto").Value = cuentaDesc
                                    grdCompras.Rows(Row.Index + 2).Cells("Concepto").Value = cuentaDesc
                                ElseIf cmbTipo.Text = "DEPÓSITOS IDENTIFICADOS" Then
                                    If grdCompras.Rows(Row.Index - 1).Cells("Cargos").Value > 0 Then
                                        grdCompras.Rows(Row.Index - 1).Cells("Concepto").Value = cuentaDesc
                                    End If
                                    Row.Cells("Bandera").Value = 1
                                End If

                                If Row.Cells("RespaldoColor").Value = "LightSteelBlue" Then
                                    grdCompras.Rows(Row.Index).Appearance.BackColor = Drawing.Color.LightSteelBlue
                                Else
                                    grdCompras.Rows(Row.Index).Appearance.BackColor = Drawing.Color.White
                                End If
                            End If
                            If Row.Cells("cuenta").Value = "" Or lblTotalAbonos2.Text <> lblTotalCargos2.Text Then
                                btnEnvioContp.Enabled = False
                            End If
                        End If
                    Next
                End If
            End If
        ElseIf e.Row.Cells("BANDERA").Value.ToString = "2" Then
            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Este cliente no existe en SAY favor de darlo de alta."
            objMesj.ShowDialog()
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        lblTotalAbonos2.Text = "0"
        lblTotalCargos2.Text = "0"
        btnEnvioContp.Enabled = True
        grdCompras.DataSource = Nothing
        Dim estaMal As Boolean
        tipoPoliza1 = CInt(cmbTipo.SelectedValue.ToString)
        estaMal = validarFechas()
        If estaMal = False Then
            estaMal = validarDatos()
            If estaMal = False Then
                Try
                    If cmbTipo.Text = "COMPRAS" Then
                        llenarTablaCompras()
                    ElseIf cmbTipo.Text = "TRANSFERENCIAS" Then
                        llenarTablaTransferencias()
                    ElseIf cmbTipo.Text = "DEPÓSITOS POR IDENTIFICAR" Then
                        llenarTablaDepositosIdentificar()
                    ElseIf cmbTipo.Text = "DEPÓSITOS IDENTIFICADOS" Then
                        llenarTablaDepositosIdedentificados()
                    ElseIf cmbTipo.Text = "VENTAS" Then
                        llenarTablaVentas()
                    ElseIf cmbTipo.Text = "GASTOS" Then
                        llenarTablaGastos()
                    ElseIf cmbTipo.Text = "GASTOS Y COMPRAS" Then
                        llenarTablaGastos()
                    ElseIf cmbTipo.Text = "PRODUCTO TERMINADO" Then
                        llenarTablaGastos()
                    ElseIf cmbTipo.Text = "GASTOS DE TRANSPORTE" Then
                        llenarTablaGastos()
                    ElseIf cmbTipo.Text = "ACTIVO FIJO" Then
                        llenarTablaActivoFijo()
                    ElseIf cmbTipo.Text = "NOTAS DE CRÉDITO" Then
                        llenarTablaNotas_De_Credito()
                    ElseIf cmbTipo.Text = "NOTAS DE CRÉDITO CANCELADAS" Then
                        llenarTablaNotas_De_Credito_Canceladas()
                    ElseIf cmbTipo.Text = "NOTAS DE CARGO" Then
                        llenarTablaNotas_De_Cargo()
                    ElseIf cmbTipo.Text = "VENTAS CANCELADAS" Then
                        llenarTablaVentasCanceladas()
                    ElseIf cmbTipo.Text = "CHEQUES POSFECHADOS" Then
                        llenarTablaChequesPosfechados()
                    ElseIf cmbTipo.Text = "DEPÓSITOS INTERNOS" Then
                        llenarTablaDepositosInternos()
                    End If
                    grdCompras.ActiveRowScrollRegion.ScrollPosition = Top
                    disenoGrid()
                Catch ex As Exception
                    Controles.Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado. Error: " + ex.Message)
                End Try
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnEnvioContp_Click(sender As Object, e As EventArgs) Handles btnEnvioContp.Click

        If grdCompras.Rows.Count > 0 Then
            Dim mensajeConfirmar As New ConfirmarForm
            If cmbTipo.Text = "COMPRAS" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar las compras? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "TRANSFERENCIAS" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar las transferencias? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "DEPÓSITOS POR IDENTIFICAR" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar los depósitos por identificar? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "DEPÓSITOS IDENTIFICADOS" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar los depósitos identificados? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "VENTAS" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar las ventas? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "GASTOS" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar los gastos? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "GASTOS Y COMPRAS" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar los gastos y las compras? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "PRODUCTO TERMINADO" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar las compras de producto terminado? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "GASTOS DE TRANSPORTE" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar los gastos de transporte? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "ACTIVO FIJO" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar los gastos de activo fijo? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "NOTAS DE CRÉDITO" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar las notas de crédito? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "NOTAS DE CRÉDITO CANCELADAS" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar las notas de crédito canceladas? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "NOTAS DE CARGO" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar las notas de cargo? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "VENTAS CANCELADAS" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar las ventas canceladas? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            ElseIf cmbTipo.Text = "CHEQUES POSFECHADOS" Then
                mensajeConfirmar.mensaje = "¿ Está seguro de querer replicar los cheques posfechados? " + vbNewLine + "El tiempo puede variar dependiendo los movimientos."
            End If

            If mensajeConfirmar.ShowDialog = DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                If cmbTipo.Text = "COMPRAS" Then
                    guardarPolizaCompras()
                ElseIf cmbTipo.Text = "TRANSFERENCIAS" Then
                    guardarPolizaTransferencias()
                ElseIf cmbTipo.Text = "DEPÓSITOS POR IDENTIFICAR" Then
                    guardarPolizaDepositosPorIdentificar()
                ElseIf cmbTipo.Text = "DEPÓSITOS IDENTIFICADOS" Then
                    guardarPolizaDepositosIdentificados()
                ElseIf cmbTipo.Text = "VENTAS" Then
                    guardarPolizaVentas()
                ElseIf cmbTipo.Text = "GASTOS" Then
                    guardarPolizaGastos(10, "Gastos a crédito")
                ElseIf cmbTipo.Text = "GASTOS Y COMPRAS" Then
                    If cmbEmpresa.SelectedValue = 6 Then
                        guardarPolizaGastos(19, "Gastos y Activo")
                    Else
                        guardarPolizaGastos(19, "Compras y Gastos a crédito")
                    End If
                ElseIf cmbTipo.Text = "PRODUCTO TERMINADO" Then
                    guardarPolizaGastos(20, "Compras de Producto Terminado")
                ElseIf cmbTipo.Text = "GASTOS DE TRANSPORTE" Then
                    guardarPolizaGastos(26, "Provisión de Fletes")
                ElseIf cmbTipo.Text = "ACTIVO FIJO" Then
                    guardarPolizaGastos(11, "Provisión Activo Fijo")
                ElseIf cmbTipo.Text = "NOTAS DE CRÉDITO" Then
                    guardarPolizaNotasCredito(7, "Notas de crédito")
                ElseIf cmbTipo.Text = "NOTAS DE CRÉDITO CANCELADAS" Then
                    guardarPolizaNotasCreditoCanceladas(7, "Notas de crédito canceladas")
                ElseIf cmbTipo.Text = "NOTAS DE CARGO" Then
                    guardarPolizaNotasCargo(8, "Notas de cargo")
                ElseIf cmbTipo.Text = "VENTAS CANCELADAS" Then
                    guardarPolizaVentasCanceladas()
                ElseIf cmbTipo.Text = "CHEQUES POSFECHADOS" Then
                    guardarPolizaChequesPosfechados()
                End If
                limpiar()
                btnEnvioContp.Enabled = False
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesAlto.Height = 39
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesAlto.Height = 120
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        limpiar()
        bloquearControles(True)
    End Sub

    Private Sub cmbEmpresa_DropDownClosed(sender As Object, e As EventArgs) Handles cmbEmpresa.DropDownClosed
        Dim objDA As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        Dim tamanio As Integer = 0

        empresaBD = ""
        servidorBD = ""
        doctoVentasID = ""
        contribuyentesID = ""
        If cmbEmpresa.SelectedIndex > 0 Then
            tabla = objDA.datosServidorEmpresa(cmbEmpresa.SelectedValue)
            For Each row As DataRow In tabla.Rows
                empresaBD = row.Item("essc_empresacontpaq")
                servidorBD = row.Item("essc_servidor")
                If tabla.Rows.Count > 1 Then
                    contribuyentesID += CStr(row.Item("essc_contribuyentesicyid")).Trim + ","
                    doctoVentasID += CStr(row.Item("essc_doctoventassicyid")).Trim + ","
                Else
                    contribuyentesID = row.Item("essc_contribuyentesicyid")
                    doctoVentasID = CStr(row.Item("essc_doctoventassicyid")).Trim
                End If
                empresaSAYContpaqSICY = row.Item("essc_empresaid")
            Next
            If tabla.Rows.Count > 1 Then
                tamanio = contribuyentesID.Length
                contribuyentesID = contribuyentesID.Remove(tamanio - 1)

                tamanio = doctoVentasID.Length
                doctoVentasID = doctoVentasID.Remove(tamanio - 1)
            End If
        End If
    End Sub

#End Region

End Class