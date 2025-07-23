Imports System.Xml

Public Class PruebaFacturacion

    Private Sub PruebaFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarEmpresas()
        cargarSucursales()
        cargarConceptos()

        cmbEmpresa.SelectedValue = 1030
        cmbSucursal.SelectedValue = 8
    End Sub

    Private Sub cargarEmpresas()
        Dim datos As New Negocios.EmpresasBU
        Dim lstEmpresas As New DataTable

        lstEmpresas = datos.getEmpresasActivas
        If Not lstEmpresas.Rows.Count = 0 Then
            'lstEmpresas.Rows.InsertAt(lstEmpresas.NewRow, 0)
            cmbEmpresa.DataSource = lstEmpresas
            cmbEmpresa.DisplayMember = "empr_nombre"
            cmbEmpresa.ValueMember = "empr_empresaid"
        End If
    End Sub

    Private Sub cargarSucursales()
        Dim datos As New Negocios.SucursalesBU
        Dim lstSucursales As New DataTable

        lstSucursales = datos.getSucursalesActivas
        If Not lstSucursales.Rows.Count = 0 Then
            'lstSucursales.Rows.InsertAt(lstSucursales.NewRow, 0)
            cmbSucursal.DataSource = lstSucursales
            cmbSucursal.DisplayMember = "suc_nombre"
            cmbSucursal.ValueMember = "suc_sucursalid"
        End If
    End Sub

    Private Sub cargarConceptos()
        grdConceptos.Rows.Add("77.00", "Pares", "MERANO CONSUL 46030 FLOR ENTERA CAJETA 25-29½", "46030", "242.00", "18634.00")
        'For i As Integer = 0 To 40
        grdConceptos.Rows.Add("77.00", "Pares", "MERANO CONSUL 46030 FLOR ENTERA NEGRO 25-29½", "46030", "231.00", "17787.00")
        'Next
    End Sub

    Private Sub btnGeneraXML_Click(sender As Object, e As EventArgs) Handles btnGeneraXML.Click
        Try
            Dim factura As New Entidades.Factura
            Dim lstconcepto As New List(Of Entidades.Conceptos)
            Dim objFactura As New Negocios.FacturaBU
            Dim empID As Integer = 0
            Dim sucID As Integer = 0
            Dim objAdv As New Tools.AdvertenciaForm

            factura.FSerie = txtSerie.Text
            factura.FFolio = txtFolio.Text
            factura.FFormaDePago = txtFormaPago.Text
            factura.FSubtotal = txtSubtotal.Text
            factura.FTotal = txtTotal.Text
            factura.FMetodoPago = txtMetodoPago.Text
            factura.FDescuento = txtDescuento.Text
            factura.FCondicionesPago = txtCondicionPago.Text

            factura.FReceptorRfc = txtRFC.Text
            factura.FReceptorNombre = txtNombre.Text
            factura.FReceptorCalle = txtCalle.Text
            factura.FReceptorNoExterior = txtNumero.Text
            factura.FReceptorColonia = txtColonia.Text
            factura.FReceptorMunicipio = txtMunicipio.Text
            factura.FReceptorEstado = txtEstado.Text
            factura.FReceptorPais = txtPais.Text
            factura.FReceptorCp = txtCP.Text

            factura.FTotalImpuestosRetenidos = txtImpTotalRetenidos.Text
            factura.FTotalImpuestosTrasladados = txtImpTotalTraslados.Text
            factura.FImpuesto = txtImpuesto.Text
            factura.FTasa = txtTasa.Text
            factura.FImpuestoTrasladadoImporte = txtImporteImp.Text

            For Each row As DataGridViewRow In grdConceptos.Rows
                If row.Cells("Cantidad").Value <> "" Then
                    Dim concepto As New Entidades.Conceptos
                    concepto.CCantidad = row.Cells("Cantidad").Value
                    concepto.CUnidad = row.Cells("Unidad").Value
                    concepto.CDescripcion = row.Cells("Descripcion").Value
                    concepto.CEstilo = row.Cells("Estilo").Value
                    concepto.CValorUnitario = row.Cells("ValorUnitario").Value
                    concepto.CImporte = row.Cells("Importe").Value
                    lstconcepto.Add(concepto)
                End If
            Next

            empID = cmbEmpresa.SelectedValue
            sucID = cmbSucursal.SelectedValue

            If Not objFactura.construirXML(factura, lstconcepto, empID, sucID, "Factura") Is Nothing Then
                MessageBox.Show("XML generado y timbrado correctamente")
                'objFactura.generarPdf()
                'MessageBox.Show("PDF generado")
            Else
                objAdv.mensaje = objFactura.msjError
                objAdv.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim factura As New Entidades.Factura
            Dim lstconcepto As New List(Of Entidades.Conceptos)
            Dim objFactura As New Negocios.FacturaBU
            Dim empID As Integer = 0
            Dim sucID As Integer = 0
            Dim objAdv As New Tools.AdvertenciaForm
            Dim resultadoCanc As String
            'Dim ruta As String = "ftp://192.168.7.16/Administracion/ConfiguracionEmpresas/GOEH8308078E0/PLAZA%20MAYOR/XML/"
            Dim ruta As String = "ftp://192.168.2.158/Administracion/ConfiguracionEmpresas/AAA010101AAA/SUCURSAL%20PRUEBA%20TIMBRADO/XML/"
            Dim pXML As String = ""
            Dim Doc As New XmlDocument
            Dim nodo As XmlNode
            Dim impSuc As Boolean

            OpenFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
            OpenFileDialog1.Filter = "XML|*.xml;"
            OpenFileDialog1.FilterIndex = 3
            OpenFileDialog1.ShowDialog()

            objFactura.guidTemp = Guid.NewGuid
            txtRutaXML.Text = ruta.Replace("%20", " ") & Mid(IO.Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName), 1, IO.Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName).Length - 3) & ".xml"
            pXML = objFactura.descargarArchivo(txtRutaXML.Text)

            Doc.Load(pXML)
            nodo = Doc.ChildNodes(1)
            factura.FSerie = nodo.Attributes.GetNamedItem("serie").Value
            factura.FFolio = nodo.Attributes.GetNamedItem("folio").Value
            factura.FFechaExpedicion = nodo.Attributes.GetNamedItem("fecha").Value
            factura.FSello = nodo.Attributes.GetNamedItem("sello").Value
            factura.FFormaDePago = nodo.Attributes.GetNamedItem("formaDePago").Value
            factura.FCondicionesPago = nodo.Attributes.GetNamedItem("condicionesDePago").Value
            factura.FSubtotal = nodo.Attributes.GetNamedItem("subTotal").Value
            factura.FTotal = nodo.Attributes.GetNamedItem("total").Value
            factura.FDescuento = nodo.Attributes.GetNamedItem("descuento").Value
            factura.FMetodoPago = nodo.Attributes.GetNamedItem("metodoDePago").Value

            If Doc.GetElementsByTagName("cfdi:Emisor").Count() = 3 Then
                impSuc = True
            Else
                impSuc = False
            End If

            nodo = Doc.ChildNodes(1).ChildNodes(1)
            factura.FReceptorRfc = nodo.Attributes.GetNamedItem("rfc").Value
            factura.FReceptorNombre = nodo.Attributes.GetNamedItem("nombre").Value
            nodo = Doc.ChildNodes(1).ChildNodes(1).ChildNodes(0)
            factura.FReceptorCalle = nodo.Attributes.GetNamedItem("calle").Value
            factura.FReceptorNoExterior = nodo.Attributes.GetNamedItem("noExterior").Value
            factura.FReceptorColonia = nodo.Attributes.GetNamedItem("colonia").Value
            factura.FReceptorMunicipio = nodo.Attributes.GetNamedItem("municipio").Value
            factura.FReceptorEstado = nodo.Attributes.GetNamedItem("estado").Value
            factura.FReceptorPais = nodo.Attributes.GetNamedItem("pais").Value
            factura.FReceptorCp = nodo.Attributes.GetNamedItem("codigoPostal").Value

            nodo = Doc.ChildNodes(1).ChildNodes(2)
            'Dim index As Integer = 0
            For item As Integer = 0 To Doc.GetElementsByTagName("cfdi:Conceptos").Count - 1
                nodo = Doc.ChildNodes(1).ChildNodes(2).ChildNodes(item)
                Dim concepto As New Entidades.Conceptos
                Dim auxConc() As String
                concepto.CCantidad = nodo.Attributes.GetNamedItem("cantidad").Value
                concepto.CUnidad = nodo.Attributes.GetNamedItem("unidad").Value
                concepto.CDescripcion = nodo.Attributes.GetNamedItem("descripcion").Value
                auxConc = Split(nodo.Attributes.GetNamedItem("descripcion").Value, " ")
                concepto.CEstilo = auxConc(2)
                concepto.CValorUnitario = nodo.Attributes.GetNamedItem("valorUnitario").Value
                concepto.CImporte = nodo.Attributes.GetNamedItem("importe").Value
                lstconcepto.Add(concepto)
                'index = index + 1
            Next

            nodo = Doc.ChildNodes(1).ChildNodes(3)
            factura.FTotalImpuestosRetenidos = nodo.Attributes.GetNamedItem("totalImpuestosRetenidos").Value
            factura.FTotalImpuestosTrasladados = nodo.Attributes.GetNamedItem("totalImpuestosTrasladados").Value
            nodo = Doc.ChildNodes(1).ChildNodes(3).ChildNodes(0).ChildNodes(0)
            factura.FImpuesto = nodo.Attributes.GetNamedItem("impuesto").Value
            factura.FTasa = nodo.Attributes.GetNamedItem("tasa").Value
            factura.FImpuestoTrasladadoImporte = nodo.Attributes.GetNamedItem("importe").Value

            nodo = Doc.ChildNodes(1).ChildNodes(4).ChildNodes(0)
            factura.FUuid = nodo.Attributes.GetNamedItem("UUID").Value
            factura.FFechaTimbrado = nodo.Attributes.GetNamedItem("FechaTimbrado").Value
            factura.FSelloCFD = nodo.Attributes.GetNamedItem("selloCFD").Value
            factura.FNoCertificadoSAT = nodo.Attributes.GetNamedItem("noCertificadoSAT").Value
            factura.FSelloSat = nodo.Attributes.GetNamedItem("selloSAT").Value


            empID = cmbEmpresa.SelectedValue
            sucID = cmbSucursal.SelectedValue

            objFactura.cancelarFactura(txtRutaXML.Text, factura, lstconcepto, empID, sucID, impSuc)
            If objFactura.msjError <> "" Then
                MessageBox.Show(objFactura.msjError)
                Exit Sub
            End If

            MessageBox.Show("Factura Generada.")
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim factura As New Entidades.Factura
            Dim lstconcepto As New List(Of Entidades.Conceptos)
            Dim objFactura As New Negocios.FacturaBU
            Dim empID As Integer = 0
            Dim sucID As Integer = 0
            Dim objAdv As New Tools.AdvertenciaForm
            Dim resultadoCanc As String
            'Dim ruta As String = "ftp://192.168.7.16/Administracion/ConfiguracionEmpresas/GOEH8308078E0/PLAZA%20MAYOR/XML/"
            Dim ruta As String = "ftp://192.168.2.158/Administracion/ConfiguracionEmpresas/AAA010101AAA/SUCURSAL%20PRUEBA%20TIMBRADO/XML/"
            Dim pXML As String = ""
            Dim Doc As New XmlDocument
            Dim nodo As XmlNode
            Dim impSuc As Boolean

            OpenFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
            OpenFileDialog1.Filter = "XML|*.xml;"
            OpenFileDialog1.FilterIndex = 3
            OpenFileDialog1.ShowDialog()

            objFactura.guidTemp = Guid.NewGuid
            TextBox1.Text = ruta.Replace("%20", " ") & Mid(IO.Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName), 1, IO.Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName).Length - 3) & ".xml"
            pXML = objFactura.descargarArchivo(TextBox1.Text)

            Doc.Load(pXML)
            nodo = Doc.ChildNodes(1)
            factura.FSerie = nodo.Attributes.GetNamedItem("serie").Value
            factura.FFolio = nodo.Attributes.GetNamedItem("folio").Value
            factura.FFechaExpedicion = nodo.Attributes.GetNamedItem("fecha").Value
            factura.FSello = nodo.Attributes.GetNamedItem("sello").Value
            factura.FFormaDePago = nodo.Attributes.GetNamedItem("formaDePago").Value
            factura.FCondicionesPago = nodo.Attributes.GetNamedItem("condicionesDePago").Value
            factura.FSubtotal = nodo.Attributes.GetNamedItem("subTotal").Value
            factura.FTotal = nodo.Attributes.GetNamedItem("total").Value
            factura.FDescuento = nodo.Attributes.GetNamedItem("descuento").Value
            factura.FMetodoPago = nodo.Attributes.GetNamedItem("metodoDePago").Value

            If Doc.GetElementsByTagName("cfdi:Emisor").Count() = 3 Then
                impSuc = True
            Else
                impSuc = False
            End If

            nodo = Doc.ChildNodes(1).ChildNodes(1)
            factura.FReceptorRfc = nodo.Attributes.GetNamedItem("rfc").Value
            factura.FReceptorNombre = nodo.Attributes.GetNamedItem("nombre").Value
            nodo = Doc.ChildNodes(1).ChildNodes(1).ChildNodes(0)
            factura.FReceptorCalle = nodo.Attributes.GetNamedItem("calle").Value
            factura.FReceptorNoExterior = nodo.Attributes.GetNamedItem("noExterior").Value
            factura.FReceptorColonia = nodo.Attributes.GetNamedItem("colonia").Value
            factura.FReceptorMunicipio = nodo.Attributes.GetNamedItem("municipio").Value
            factura.FReceptorEstado = nodo.Attributes.GetNamedItem("estado").Value
            factura.FReceptorPais = nodo.Attributes.GetNamedItem("pais").Value
            factura.FReceptorCp = nodo.Attributes.GetNamedItem("codigoPostal").Value

            nodo = Doc.ChildNodes(1).ChildNodes(2)
            'Dim index As Integer = 0
            For item As Integer = 0 To Doc.GetElementsByTagName("cfdi:Conceptos").Count
                nodo = Doc.ChildNodes(1).ChildNodes(2).ChildNodes(item)
                Dim concepto As New Entidades.Conceptos
                Dim auxConc() As String
                concepto.CCantidad = nodo.Attributes.GetNamedItem("cantidad").Value
                concepto.CUnidad = nodo.Attributes.GetNamedItem("unidad").Value
                concepto.CDescripcion = nodo.Attributes.GetNamedItem("descripcion").Value
                auxConc = Split(nodo.Attributes.GetNamedItem("descripcion").Value, " ")
                concepto.CEstilo = auxConc(2)
                concepto.CValorUnitario = nodo.Attributes.GetNamedItem("valorUnitario").Value
                concepto.CImporte = nodo.Attributes.GetNamedItem("importe").Value
                lstconcepto.Add(concepto)
                'index = index + 1
            Next

            nodo = Doc.ChildNodes(1).ChildNodes(3)
            factura.FTotalImpuestosRetenidos = nodo.Attributes.GetNamedItem("totalImpuestosRetenidos").Value
            factura.FTotalImpuestosTrasladados = nodo.Attributes.GetNamedItem("totalImpuestosTrasladados").Value
            nodo = Doc.ChildNodes(1).ChildNodes(3).ChildNodes(0).ChildNodes(0)
            factura.FImpuesto = nodo.Attributes.GetNamedItem("impuesto").Value
            factura.FTasa = nodo.Attributes.GetNamedItem("tasa").Value
            factura.FImpuestoTrasladadoImporte = nodo.Attributes.GetNamedItem("importe").Value

            nodo = Doc.ChildNodes(1).ChildNodes(4).ChildNodes(0)
            factura.FUuid = nodo.Attributes.GetNamedItem("UUID").Value
            factura.FFechaTimbrado = nodo.Attributes.GetNamedItem("FechaTimbrado").Value
            factura.FSelloCFD = nodo.Attributes.GetNamedItem("selloCFD").Value
            factura.FNoCertificadoSAT = nodo.Attributes.GetNamedItem("noCertificadoSAT").Value
            factura.FSelloSat = nodo.Attributes.GetNamedItem("selloSAT").Value
            objFactura.eliminaArchivosTemp()

            empID = cmbEmpresa.SelectedValue
            sucID = cmbSucursal.SelectedValue

            If objFactura.regeneraPDF(0, factura, lstconcepto, empID, sucID, "Factura", impSuc, 57) Then
                MessageBox.Show("PDF generado nuevamente")
            Else
                MessageBox.Show(objFactura.msjError)
            End If
            If objFactura.msjError <> "" Then
                MessageBox.Show(objFactura.msjError)
            End If
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim factura As New Entidades.Factura
            Dim lstconcepto As New List(Of Entidades.Conceptos)
            Dim objFactura As New Negocios.FacturaBU
            Dim empID As Integer = 0
            Dim sucID As Integer = 0
            Dim objAdv As New Tools.AdvertenciaForm
            Dim ruta As String = "ftp://192.168.7.16/Administracion/ConfiguracionEmpresas/GOEH8308078E0/PLAZA%20MAYOR/XML/"
            'Dim ruta As String = "ftp://192.168.7.16/Administracion/ConfiguracionEmpresas/AAA010101AAA/SUCURSAL%20PRUEBA%20TIMBRADO/XML/"
            Dim pXML As String = ""
            Dim pXMLCan As String = ""
            Dim Doc As New XmlDocument
            Dim nodo As XmlNode
            Dim impSuc As Boolean
            Dim fechaCan As String
            Dim estatusCan As String

            OpenFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
            OpenFileDialog1.Filter = "XML|*.xml;"
            OpenFileDialog1.FilterIndex = 3
            OpenFileDialog1.ShowDialog()

            objFactura.guidTemp = Guid.NewGuid
            TextBox1.Text = ruta.Replace("%20", " ") & Mid(IO.Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName), 1, IO.Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName).Length - 3) & ".xml"
            pXML = objFactura.descargarArchivo(TextBox1.Text)

            Doc.Load(pXML)
            nodo = Doc.ChildNodes(1)
            factura.FSerie = nodo.Attributes.GetNamedItem("serie").Value
            factura.FFolio = nodo.Attributes.GetNamedItem("folio").Value
            factura.FFechaExpedicion = nodo.Attributes.GetNamedItem("fecha").Value
            factura.FSello = nodo.Attributes.GetNamedItem("sello").Value
            factura.FFormaDePago = nodo.Attributes.GetNamedItem("formaDePago").Value
            factura.FCondicionesPago = nodo.Attributes.GetNamedItem("condicionesDePago").Value
            factura.FSubtotal = nodo.Attributes.GetNamedItem("subTotal").Value
            factura.FTotal = nodo.Attributes.GetNamedItem("total").Value
            factura.FDescuento = nodo.Attributes.GetNamedItem("descuento").Value
            factura.FMetodoPago = nodo.Attributes.GetNamedItem("metodoDePago").Value

            If Doc.GetElementsByTagName("cfdi:Emisor").Count() > 2 Then
                impSuc = True
            Else
                impSuc = False
            End If

            nodo = Doc.ChildNodes(1).ChildNodes(1)
            factura.FReceptorRfc = nodo.Attributes.GetNamedItem("rfc").Value
            factura.FReceptorNombre = nodo.Attributes.GetNamedItem("nombre").Value
            nodo = Doc.ChildNodes(1).ChildNodes(1).ChildNodes(0)
            factura.FReceptorCalle = nodo.Attributes.GetNamedItem("calle").Value
            factura.FReceptorNoExterior = nodo.Attributes.GetNamedItem("noExterior").Value
            factura.FReceptorColonia = nodo.Attributes.GetNamedItem("colonia").Value
            factura.FReceptorMunicipio = nodo.Attributes.GetNamedItem("municipio").Value
            factura.FReceptorEstado = nodo.Attributes.GetNamedItem("estado").Value
            factura.FReceptorPais = nodo.Attributes.GetNamedItem("pais").Value
            factura.FReceptorCp = nodo.Attributes.GetNamedItem("codigoPostal").Value

            nodo = Doc.ChildNodes(1).ChildNodes(2)
            'Dim index As Integer = 0
            For item As Integer = 0 To Doc.GetElementsByTagName("cfdi:Conceptos").Count
                nodo = Doc.ChildNodes(1).ChildNodes(2).ChildNodes(item)
                Dim concepto As New Entidades.Conceptos
                Dim auxConc() As String
                concepto.CCantidad = nodo.Attributes.GetNamedItem("cantidad").Value
                concepto.CUnidad = nodo.Attributes.GetNamedItem("unidad").Value
                concepto.CDescripcion = nodo.Attributes.GetNamedItem("descripcion").Value
                auxConc = Split(nodo.Attributes.GetNamedItem("descripcion").Value, " ")
                concepto.CEstilo = auxConc(2)
                concepto.CValorUnitario = nodo.Attributes.GetNamedItem("valorUnitario").Value
                concepto.CImporte = nodo.Attributes.GetNamedItem("importe").Value
                lstconcepto.Add(concepto)
                'index = index + 1
            Next

            nodo = Doc.ChildNodes(1).ChildNodes(3)
            factura.FTotalImpuestosRetenidos = nodo.Attributes.GetNamedItem("totalImpuestosRetenidos").Value
            factura.FTotalImpuestosTrasladados = nodo.Attributes.GetNamedItem("totalImpuestosTrasladados").Value
            nodo = Doc.ChildNodes(1).ChildNodes(3).ChildNodes(0).ChildNodes(0)
            factura.FImpuesto = nodo.Attributes.GetNamedItem("impuesto").Value
            factura.FTasa = nodo.Attributes.GetNamedItem("tasa").Value
            factura.FImpuestoTrasladadoImporte = nodo.Attributes.GetNamedItem("importe").Value

            nodo = Doc.ChildNodes(1).ChildNodes(4).ChildNodes(0)
            factura.FUuid = nodo.Attributes.GetNamedItem("UUID").Value
            factura.FFechaTimbrado = nodo.Attributes.GetNamedItem("FechaTimbrado").Value
            factura.FSelloCFD = nodo.Attributes.GetNamedItem("selloCFD").Value
            factura.FNoCertificadoSAT = nodo.Attributes.GetNamedItem("noCertificadoSAT").Value
            factura.FSelloSat = nodo.Attributes.GetNamedItem("selloSAT").Value

            OpenFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
            OpenFileDialog1.Filter = "XML|*.xml;"
            OpenFileDialog1.FilterIndex = 3
            OpenFileDialog1.ShowDialog()
            TextBox2.Text = ruta.Replace("%20", " ") & Mid(IO.Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName), 1, IO.Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName).Length - 3) & ".xml"
            pXMLCan = objFactura.descargarArchivo(TextBox2.Text)

            Doc.Load(pXMLCan)
            nodo = Doc.ChildNodes(0).ChildNodes(0)
            fechaCan = nodo.ChildNodes.Item(2).InnerText
            estatusCan = nodo.ChildNodes.Item(3).InnerText

            objFactura.eliminaArchivosTemp()

            empID = cmbEmpresa.SelectedValue
            sucID = cmbSucursal.SelectedValue

            If objFactura.regeneraPDF(0, factura, lstconcepto, empID, sucID, "Cancelacion", impSuc, 58, estatusCan, fechaCan) Then
                MessageBox.Show("PDF generado nuevamente")
                If objFactura.msjError <> "" Then
                    MessageBox.Show(objFactura.msjError)
                End If
            Else
                MessageBox.Show(objFactura.msjError)
            End If
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub btnRegenerarPDF_WS_Click(sender As Object, e As EventArgs) Handles btnRegenerarPDF_WS.Click
        Dim objBu As New Facturacion.Negocios.WebFacturasBU
        Dim factura As New Entidades.Factura
        Dim lstConceptos As New List(Of Entidades.Conceptos)

        factura = objBu.obtenerFactura(1)
        lstConceptos = objBu.obtenerProductosFactura(1)
    End Sub
End Class