Imports System.Xml
Imports System.IO
Imports Tools
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid

Public Class AdministrarComplementoPagoCompensacion_Form
#Region "Globales"
    Public idCfdi As Integer = 0
    Private idCrpAjuste As Integer = 0
    Private rutaXmlRelacionado As String = String.Empty
    Private rutaPdfRelacionado As String = String.Empty
    Private rutaArchivos As String = Entidades.SesionUsuario.ConfigRutas.PRutaCRP_Compensacion.ToString '"\\192.168.2.2\bin\TASFE\CRP_Ajustes\"
#End Region

#Region "Eventos"
    Private Sub AdministrarComplementoPagoCompensacion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        llenarComboCadena()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click, lblLimpiar.Click
        limpiarFiltros()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click, lblCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnSeleccionarCfdi_Click(sender As Object, e As EventArgs) Handles btnSeleccionarCfdi.Click, lblSeleccionarCfdi.Click
        If validaCliente() Then
            Dim objForm As New SeleccionarCFDIForm
            If Not CheckForm(objForm) Then
                objForm.idCliente = cmbCliente.SelectedValue
                objForm.ShowDialog()
                pnlGuardar.Enabled = True
                pnlRelacionarXml.Enabled = True
                pnlRelacionarPDF.Enabled = True
                lblGenerado.Visible = False
                idCfdi = objForm.idCfdi
                llenarListado()
            End If
        End If
    End Sub

    Private Sub btnRelacionarXml_Click(sender As Object, e As EventArgs) Handles btnRelacionarXml.Click, lblRelacionarXml.Click
        ofdRelacionarXml.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRelacionarXml.Filter = "XML|*.xml;"
        ofdRelacionarXml.FilterIndex = 3
        ofdRelacionarXml.ShowDialog()
        If System.IO.Path.GetExtension(ofdRelacionarXml.FileName).ToUpper <> "XML" Then
            rutaXmlRelacionado = ofdRelacionarXml.FileName
            If (rutaXmlRelacionado <> "") Then
                cargarDatosXml()
            End If
        Else
            show_message("Advertencia", "El archivo seleccionado no es un XML")
        End If
    End Sub

    Private Sub btnRelacionarPDF_Click(sender As Object, e As EventArgs) Handles btnRelacionarPDF.Click, lblRelacionarPDF.Click
        ofdRelacionarPdf.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRelacionarPdf.Filter = "PDF|*.pdf;"
        ofdRelacionarPdf.FilterIndex = 3
        ofdRelacionarPdf.ShowDialog()
        If System.IO.Path.GetExtension(ofdRelacionarPdf.FileName).ToUpper <> "PDF" Then
            rutaPdfRelacionado = ofdRelacionarPdf.FileName
        Else
            show_message("Advertencia", "El archivo seleccionado no es un PDF")
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click, lblGuardar.Click
        guardar()
    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged
        idCfdi = 0

        txtCrpCompensacion.Text = String.Empty
        txtSerieFolioCrp.Text = String.Empty
        dtpFechaCrp.Value = Date.Now

        grdListado.DataSource = Nothing
        lblGenerado.Visible = False
        pnlGuardar.Enabled = True
        pnlRelacionarXml.Enabled = True
        pnlRelacionarPDF.Enabled = True
    End Sub

    Private Sub btnTimbrar_Click(sender As Object, e As EventArgs) Handles btnTimbrar.Click, lblTimbrar.Click
        timbrar()
    End Sub
#End Region

#Region "Metodos"
    Private Sub llenarComboCadena()
        Tools.Controles.ComboCadenasSicy(cmbCliente)
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)
        Dim objMensaje As Object

        Select Case tipo
            Case "Advertencia"
                objMensaje = New AdvertenciaForm
            Case "Aviso"
                objMensaje = New AvisoForm
            Case "Error"
                objMensaje = New ErroresForm
            Case "Exito"
                objMensaje = New ExitoForm
            Case "Confirmar"
                objMensaje = New ConfirmarForm
            Case "AdvertenciaGrande"
                objMensaje = New AdvertenciaFormGrande
            Case Else
                objMensaje = New AvisoForm
        End Select

        objMensaje.mensaje = mensaje
        objMensaje.ShowDialog()
    End Sub

    Private Function validaCliente() As Boolean
        If cmbCliente.Items.Count > 1 And cmbCliente.SelectedIndex = 0 Then
            show_message("Advertencia", "Favor de seleccionar un cliente.")
            Return False
        End If

        Return True
    End Function

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Sub llenarListado()
        Me.Cursor = Cursors.WaitCursor
        grdListado.DataSource = Nothing
        If idCfdi <> 0 Then
            Try
                Dim objBU As New Negocios.AdministrarComplementoPagoCompensacionBU
                Dim dtListado As New DataTable
                Dim dtValidaCrp As New DataTable
                Dim crpAjuste As Integer = 0

                dtValidaCrp = objBU.validaCRPAjuste(idCfdi)
                If Not dtValidaCrp Is Nothing Then
                    If dtValidaCrp.Rows.Count > 0 Then
                        crpAjuste = CInt(dtValidaCrp.Rows(0)("ComplementoId").ToString)
                        If (dtValidaCrp.Rows(0)("UUID").ToString = String.Empty) Then
                            lblGenerado.Visible = True
                        Else
                            txtCrpCompensacion.Text = dtValidaCrp.Rows(0)("UUID").ToString
                            txtSerieFolioCrp.Text = dtValidaCrp.Rows(0)("Serie").ToString & "-" & dtValidaCrp.Rows(0)("Folio").ToString
                            dtpFechaCrp.Value = CDate(dtValidaCrp.Rows(0)("Fecha").ToString)
                        End If
                        pnlGuardar.Enabled = False
                    End If
                End If

                dtListado = objBU.obtenerAjuste(idCfdi)
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        grdListado.DataSource = dtListado
                        disenioGrid()

                        If cmbCliente.SelectedValue <> 947 Then
                            txtTotalCfdi.Enabled = True
                            txtTotalCfdi.ReadOnly = False
                        End If

                    Else
                        show_message("Advertencia", "La consulta no devolvió ningún resultado")
                    End If
                Else
                    show_message("Advertencia", "La consulta no devolvió ningún resultado")
                End If
            Catch ex As Exception
                show_message("Error", "Error al cargar listado de CRP.")
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub disenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridView1.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            If col.FieldName <> " " And col.FieldName.Contains("XML") = False And col.FieldName.Contains("PDF") = False Then
                GridView1.Columns.ColumnByFieldName(col.FieldName).OptionsColumn.AllowEdit = False
            End If
        Next

        With GridView1
            .Columns("RutaXML").Visible = False
            .Columns("RutaPDF").Visible = False

            .Columns("#").Width = 45
            .Columns("XML").Width = 45
            .Columns("PDF").Width = 45
            .Columns("Serie").Width = 150
            .Columns("Folio").Width = 150
            .Columns("UUID").Width = 400

            .Columns("Folio").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
            .Columns("Total").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
            .Columns("Aplicado").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
            .Columns("Por Aplicar").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
            .Columns("Parcialidad").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far

            .Columns.ColumnByFieldName("XML").OptionsColumn.AllowEdit = True
            .Columns.ColumnByFieldName("PDF").OptionsColumn.AllowEdit = True

            .Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            .Columns.ColumnByFieldName("Aplicado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            .Columns.ColumnByFieldName("Por Aplicar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            .Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N2"
            .Columns.ColumnByFieldName("Aplicado").DisplayFormat.FormatString = "N2"
            .Columns.ColumnByFieldName("Por Aplicar").DisplayFormat.FormatString = "N2"

            .OptionsView.EnableAppearanceEvenRow = True
            .OptionsView.EnableAppearanceOddRow = True
        End With

        If IsNothing(GridView1.Columns("Total").Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True Then
            GridView1.Columns("Total").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:N2}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "sumTotal"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0:N2}"
            GridView1.GroupSummary.Add(item)
        End If

        If IsNothing(GridView1.Columns("Aplicado").Summary.FirstOrDefault(Function(x) x.FieldName = "Aplicado")) = True Then
            GridView1.Columns("Aplicado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Aplicado", "{0:N2}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "sumAplicado"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0:N2}"
            GridView1.GroupSummary.Add(item)
        End If

        If IsNothing(GridView1.Columns("Por Aplicar").Summary.FirstOrDefault(Function(x) x.FieldName = "Por Aplicar")) = True Then
            GridView1.Columns("Por Aplicar").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Por Aplicar", "{0:N2}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "sumPorAplicar"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0:N2}"
            GridView1.GroupSummary.Add(item)
        End If

        grdListado.RepositoryItems.Clear()
        AddGridColumnButton("XML")
        AddGridColumnButton("PDF")
    End Sub

    Public Sub AddGridColumnButton(ByVal FieldName As String)
        If grdListado Is Nothing Then Exit Sub

        Dim _RIButton As New RepositoryItemButtonEdit
        grdListado.RepositoryItems.Add(_RIButton)

        GridView1.Columns(FieldName).ShowButtonMode = Views.Base.ShowButtonModeEnum.ShowAlways
        GridView1.Columns(FieldName).UnboundType = DevExpress.Data.UnboundColumnType.Object
        GridView1.Columns(FieldName).ColumnEdit = _RIButton
        _RIButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _RIButton.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        _RIButton.Buttons(0).Image = My.Resources._1373583708_10

        If FieldName = "XML" Or FieldName = "PDF" Then
            _RIButton.Buttons(0).Width = GridView1.Columns(FieldName).Width - (GridView1.Columns(FieldName).Width / 4)
        End If

        If FieldName = "XML" Then
            AddHandler _RIButton.ButtonClick, AddressOf ColumnaXML_Click
        End If
        If FieldName = "PDF" Then
            AddHandler _RIButton.ButtonClick, AddressOf ColumnaPDF_Click
        End If
    End Sub

    Private Sub ColumnaXML_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        DescargarArchivoComplementoPago("RutaXML")
    End Sub

    Private Sub ColumnaPDF_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        DescargarArchivoComplementoPago("RutaPDF")
    End Sub

    Private Sub DescargarArchivoComplementoPago(ByVal tipoArchivo As String)
        Cursor = Cursors.WaitCursor
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = GridView1.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If GridView1.IsRowSelected(GridView1.GetVisibleRowHandle(index)) Then
                    Process.Start(GridView1.GetRowCellValue(GridView1.GetVisibleRowHandle(index), tipoArchivo))
                End If
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub limpiarFiltros()
        idCfdi = 0
        idCrpAjuste = 0

        rutaXmlRelacionado = String.Empty
        rutaPdfRelacionado = String.Empty
        ofdRelacionarXml.FileName = String.Empty
        ofdRelacionarPdf.FileName = String.Empty

        cmbCliente.SelectedIndex = 0

        txtCfdiCliente.Text = String.Empty
        txtSerieFolioCfdi.Text = String.Empty
        dtpFechaCfdi.Value = Date.Now
        txtTotalCfdi.Text = String.Empty

        txtCrpCompensacion.Text = String.Empty
        txtSerieFolioCrp.Text = String.Empty
        dtpFechaCrp.Value = Date.Now

        grdListado.DataSource = Nothing
        lblGenerado.Visible = False
        pnlGuardar.Enabled = True
        pnlRelacionarXml.Enabled = True
        pnlRelacionarPDF.Enabled = True
    End Sub

    Private Sub cargarDatosXml()
        Try
            Dim doc As New XmlDocument
            Dim factura As XmlNode
            Dim nodo As XmlNode
            Dim timbre As XmlNode
            Dim xmlmanager As System.Xml.XmlNamespaceManager

            doc.Load(rutaXmlRelacionado)
            xmlmanager = New XmlNamespaceManager(doc.NameTable)
            xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
            xmlmanager.AddNamespace("tfd", "http://www.sat.gob.mx/timbrefiscaldigital")
            factura = doc.SelectSingleNode("cfdi:Comprobante", xmlmanager)
            nodo = factura.SelectSingleNode("cfdi:Complemento", xmlmanager)
            timbre = nodo.FirstChild()

            If Not timbre Is Nothing Then
                If timbre.Attributes.GetNamedItem("UUID").Value <> "" Then
                    txtCfdiCliente.Text = timbre.Attributes.GetNamedItem("UUID").Value
                    txtSerieFolioCfdi.Text = factura.Attributes.GetNamedItem("Serie").Value & "-" & factura.Attributes.GetNamedItem("Folio").Value
                    dtpFechaCfdi.Text = CDate(timbre.Attributes.GetNamedItem("FechaTimbrado").Value)
                    txtTotalCfdi.Text = CDbl(factura.Attributes.GetNamedItem("Total").Value).ToString("N2")
                End If
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub guardar()
        Dim objBU As New Negocios.AdministrarComplementoPagoCompensacionBU
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        Try
            If cmbCliente.SelectedValue <> 947 Then
                Me.Cursor = Cursors.WaitCursor
                dtResultado = objBU.generarAjuste(idCfdi, "", "")
                If Not dtResultado Is Nothing Then
                    resultado = dtResultado.Rows(0)("mensaje").ToString
                    If resultado = "EXITO" Then
                        'llenarListado()
                        idCrpAjuste = CInt(dtResultado.Rows(0)("ID").ToString)
                        pnlGuardar.Enabled = False
                        show_message("Exito", "El ajuste del CRP se guardo correctamente.")
                    Else
                        show_message("Advertencia", resultado)
                    End If
                Else
                    show_message("Error", "Error al guardar ajuste de CRP.")
                End If
                Me.Cursor = Cursors.Default
            Else
                If validarGuardar() Then
                    Me.Cursor = Cursors.WaitCursor

                    Dim rutaXml As String = subirArchivo(rutaXmlRelacionado)
                    Dim rutaPdf As String = subirArchivo(rutaPdfRelacionado)

                    dtResultado = objBU.generarAjuste(idCfdi, rutaXml, rutaPdf)
                    If Not dtResultado Is Nothing Then
                        resultado = dtResultado.Rows(0)("mensaje").ToString
                        If resultado = "EXITO" Then
                            'llenarListado()
                            idCrpAjuste = CInt(dtResultado.Rows(0)("ID").ToString)
                            pnlGuardar.Enabled = False
                            pnlRelacionarXml.Enabled = False
                            pnlRelacionarPDF.Enabled = False
                            show_message("Exito", "El ajuste del CRP se guardo correctamente.")
                        Else
                            show_message("Advertencia", resultado)
                        End If
                    Else
                        show_message("Error", "Error al guardar ajuste de CRP.")
                    End If

                    Me.Cursor = Cursors.Default
                End If
            End If
        Catch ex As Exception
            show_message("Error", "Error al guardar ajuste de CRP.")
        End Try


    End Sub

    Private Function validarGuardar() As Boolean
        If GridView1.RowCount = 0 Then
            show_message("Advertencia", "Debe cargar el CRP inicial")
            Return False
        End If

        If rutaXmlRelacionado = "" Then
            show_message("Advertencia", "Debe relacionar un XML")
            Return False
        End If

        Dim sumTotal As String = GridView1.Columns("Por Aplicar").SummaryItem.SummaryValue.ToString
        sumTotal = Replace(sumTotal, ",", "")
        Dim diferencia = Math.Abs(CDbl(Replace(txtTotalCfdi.Text, ",", "")) - CDbl(sumTotal))
        If diferencia > 1 Then
            show_message("Advertencia", "El total del XML relacionado no coincide con el total por aplicar")
            Return False
        End If

        If rutaPdfRelacionado = "" Then
            show_message("Advertencia", "Debe relacionar un PDF")
            Return False
        End If

        Return True
    End Function

    Private Sub timbrar()
        If validarTimbrar() Then
            Dim objBu As New Negocios.AdministradorComplementoRecepcionPagosBU
            Dim dtResultadoGenerarDatosTimbrado As New DataTable
            Dim confirmacion As New Tools.ConfirmarForm

            Try
                If idCrpAjuste <> 0 Then
                    confirmacion.mensaje = "Se timbrará el complemento #" + idCrpAjuste.ToString() + ". ¿Desea continuar?"
                    If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        dtResultadoGenerarDatosTimbrado = objBu.generarDatosTimbrarComplemento(idCrpAjuste)

                        If dtResultadoGenerarDatosTimbrado.Rows.Count > 0 Then
                            Dim resultado As String = String.Empty
                            Dim mensaje As String = String.Empty

                            resultado = dtResultadoGenerarDatosTimbrado.Rows(0).Item("Resultado").ToString()
                            mensaje = dtResultadoGenerarDatosTimbrado.Rows(0).Item("Mensaje").ToString()

                            If resultado = "Exito" Then
                                Dim idEmpresa = CInt(dtResultadoGenerarDatosTimbrado.Rows(0).Item("idEmpresa"))
                                Dim objComplemento As New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
                                objComplemento.FolioComplementoPago(idCrpAjuste, idEmpresa)
                                Dim aviso As String = objComplemento.Aviso
                                Dim respuesta As Int16 = objComplemento.Respuesta
                                'Dim aviso As String = String.Empty
                                'Dim respuesta As Int16 = 1
                                If respuesta = 1 Then
                                    aviso = ""
                                    respuesta = 0
                                    objComplemento.CopiarDocumento()
                                    aviso = objComplemento.Aviso
                                    respuesta = objComplemento.Respuesta
                                    If respuesta = 1 Then
                                        'Process.Start(objtimbradoBU.RutaCliente)
                                        objComplemento = New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
                                        objComplemento.GenerarPdfComplementoPago(idCrpAjuste)
                                        respuesta = 0
                                        aviso = String.Empty
                                        respuesta = objComplemento.Respuesta
                                        aviso = objComplemento.Aviso
                                        If respuesta = 1 Then
                                            aviso = ""
                                            respuesta = 0
                                            objComplemento.CopiarDocumento()
                                            aviso = objComplemento.Aviso
                                            respuesta = objComplemento.Respuesta
                                            If respuesta = 1 Then
                                                Dim ajusteBU As New Negocios.AdministrarComplementoPagoCompensacionBU
                                                Dim stCobros As String = String.Empty

                                                stCobros = ajusteBU.generarCobros(idCrpAjuste)
                                                If stCobros <> "EXITO" Then
                                                    show_message("Error", stCobros)
                                                End If

                                                'enviarCorreo()
                                                show_message("Exito", aviso)
                                                limpiarFiltros()
                                            Else
                                                MsgBox(aviso)
                                            End If
                                        Else
                                            MsgBox(aviso)
                                        End If
                                    Else
                                        MsgBox(aviso)
                                    End If
                                Else
                                    MsgBox(aviso)
                                End If
                            Else
                                show_message("Error", mensaje)
                            End If

                        Else
                            MsgBox("El procedimiento no arrojo niungun resultado.")
                        End If
                    End If
                End If
            Catch ex As Exception
                show_message("Error", ex.Message)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Function validarTimbrar() As Boolean
        If Not validarGuardar() Then
            Return False
        End If

        If idCrpAjuste = 0 Then
            show_message("Advertencia", "Debe guardar el ajuste para timbrar")
            Return False
        End If

        Return True
    End Function

    Private Sub enviarCorreo()
        Dim objBU As New Negocios.AdministrarComplementoPagoCompensacionBU
        Dim dtResultado As New DataTable
        Cursor = Cursors.WaitCursor
        Try
            dtResultado = objBU.obtenerCRPAjuste(idCrpAjuste)
            If Not dtResultado Is Nothing Then
                If dtResultado.Rows.Count > 0 Then
                    Dim email As String = dtResultado.Rows(0)("Email").ToString
                    Dim pathXml As String = dtResultado.Rows(0)("RutaXML").ToString
                    Dim pathPdf As String = dtResultado.Rows(0)("RutaPDF").ToString
                    enviarCorreoComplementoDePago(idCrpAjuste, email, pathXml, pathPdf)
                Else
                    show_message("Error", "El procedimiento de enviar no obtuvo resultados, intente de nuevo")
                End If
            Else
                show_message("Error", "El procedimiento de enviar no obtuvo resultados, intente de nuevo")
            End If
        Catch
            show_message("Error", "Ocurrio un error al enviar, intente de nuevo")
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Function enviarCorreoComplementoDePago(ByVal IdComplemento As Integer, CorreosDestinatario As String, rutaArchivoXML As String, rutaArchivoPDF As String) As Boolean
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim dtResultadoDatosCorreos As New DataTable
        Dim remitente As String = String.Empty
        Dim correo As New Tools.Correo
        Dim cadenaCorreo As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        Dim objBU As New Negocios.AdministradorComplementoRecepcionPagosBU
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim CorreoEnviado As String = String.Empty
        Dim StatusCorreo As Boolean = False

        Cursor = Cursors.WaitCursor
        Try

            dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")
            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()

            If rutaArchivoPDF <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

            If rutaArchivoXML <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoXML)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If


            asuntoCorreo = "Asunto: CFDI de Complemento de Recibo de Pago (CRP)"
            cadenaCorreo = "<html> " +
                           " <head>" +
                           " </head>"
            cadenaCorreo += " <body> "
            cadenaCorreo += " <br><p>Estimado Cliente: Anexo encontrará su CFDI de recibo de pago (CRP) en formato PDF y XML.</p>"
            cadenaCorreo += " <p> Le sugerimos tomar en cuenta las siguientes consideraciones en cuanto a cancelaciones:<br>"
            cadenaCorreo += " <ol>" +
                            "<li> Cualquier cambio en el recibo de pago, en caso de que este proceda se realizará Únicamente dentro de los primeros 7 días posteriores a la expedición del comprobante; pasando este lapso de días no se harán cambios.</li>" +
                            "<li> No Procederá la cancelación de un CFDI de recibo de pago (CRP) que se haya facturado conforme a los datos proporcionados por usted mismo. </li>" +
                            "<li> Los documentos relacionados que se tomarán en cuenta para realizar el CFDI de pago son aquellos que usted nos proporcionó en la notificación de pago, de no recibir la notificación el pago se aplicará a los CFDI pendientes de pago más antiguos de acuerdo a lo estipulado en la regla 2.7.1.35 de la RMF.</li>" +
                            "<li> El recibo de pago (CRP) fue emitido solo con los datos obligatorios que actualmente se encuentran regulados por el SAT (Guía de llenado del ""Complemento para recepción de Pagos”") . Por lo tanto en el recibo no verán reflejados los datos bancarios (NumOperacion, RfcEmisorCtaOrd, CtaOrdenante, RfcEmisorCtaBen, CtaBeneficiario, TipoCadPago, CertPago, CadPago, SelloPago)</li>" +
                            "</ol>" +
                            "</p>"
            cadenaCorreo += " <p> Atentamente: Grupo Yuyin </p>"
            cadenaCorreo += " </body> " +
                            " </html> "

            entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)

            If entCorreo.CorreoEnviado = True Then
                CorreoEnviado = "S"
                StatusCorreo = True
            Else
                CorreoEnviado = "N"
                StatusCorreo = False
            End If

            'Actualizar Status Correo Enviado SAY
            objBU.ActualizarStatusCorreoEnviadoCRP(IdComplemento, CorreoEnviado, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            objBU.RegistraBitacoraEnvio(IdComplemento, CorreoEnviado, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)


        Catch ex As Exception
            StatusCorreo = False
        End Try

        Return StatusCorreo

        Cursor = Cursors.Default

    End Function

    Public Function existeCarpeta(ByVal ruta As String) As Boolean
        Dim exists As Boolean
        exists = System.IO.Directory.Exists(ruta)
        Return exists
    End Function

    Public Sub crearCarpeta(ByVal ruta As String)
        System.IO.Directory.CreateDirectory(ruta)
    End Sub

    Private Function subirArchivo(ByVal ruta As String) As String
        Dim rutaArchivo As String = ""
        Try
            Dim filesPath As String = rutaArchivos & cmbCliente.Text & "\" & dtpFechaCfdi.Value.ToString("yyyyMMdd") & "\"
            If Not existeCarpeta(filesPath) Then
                crearCarpeta(filesPath)
            End If

            My.Computer.FileSystem.CopyFile(ruta, filesPath & Path.GetFileName(ruta), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            rutaArchivo = filesPath & Path.GetFileName(ruta)
            Return rutaArchivo
        Catch
            Return rutaArchivo
        End Try
    End Function



#End Region
End Class