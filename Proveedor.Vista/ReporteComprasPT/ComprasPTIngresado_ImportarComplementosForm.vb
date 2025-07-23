Imports System.IO
Imports System.Windows.Forms
Imports Tools
Imports DevExpress.XtraGrid
Imports System.Xml

Public Class ComprasPTIngresado_ImportarComplementosForm
    Dim objBU As New Proveedores.BU.ComplementosComprasPT_BU
    Dim EntXML As Entidades.FacturaComplementoXML
    Dim ArchivoPDF As String = String.Empty
    Dim ArchivoXML As String = String.Empty
    Dim blnCargaExcel As Boolean = False
    Dim blnCargaXML As Boolean = False
    Dim blnCargaPDF As Boolean = False

    Private Sub ComprasPTIngresado_ImportarComplementosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        AgregarGridExcel()
    End Sub

    Private Sub AgregarGridExcel()
        Dim dtDatos As New DataTable
        blnCargaExcel = False
        blnCargaXML = False
        blnCargaPDF = False

        dtDatos = ImportarExcel()

        If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
            For Each row As DataRow In dtDatos.Rows
                If row.Item(5) <= 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Existen artículos con precios incorrectos o sin asignar, favor de verificar los datos.")
                    Exit Sub
                End If
            Next

            grdListado.DataSource = dtDatos
            disenioGrid()
            blnCargaExcel = True
        End If
    End Sub

    Public Function ImportarExcel() As DataTable
        Dim datosExcel As New DataTable
        Dim NombreArchivo As String = ""
        Dim NumRenglon As Integer = 0
        Dim NumRenglonDataTable As Integer = 0
        Dim NumColumna As Integer = 0
        Dim dtDatosMostarImportados As New DataTable

        Try
            Dim hoja As String = ""
            datosExcel = leerExcel()

            Cursor = Cursors.WaitCursor
            If IsNothing(datosExcel) = False AndAlso datosExcel.Rows.Count > 0 Then
                Dim renglonExcel As Integer = 0
                dtDatosMostarImportados.Columns.Add("RazonSocial", Type.GetType("System.String"))
                dtDatosMostarImportados.Columns.Add("RFC", Type.GetType("System.String"))
                dtDatosMostarImportados.Columns.Add("Observaciones", Type.GetType("System.Int32"))
                dtDatosMostarImportados.Columns.Add("Concepto", Type.GetType("System.String"))
                dtDatosMostarImportados.Columns.Add("Cantidad", Type.GetType("System.Int32"))
                dtDatosMostarImportados.Columns.Add("Precio", Type.GetType("System.Double"))
                dtDatosMostarImportados.Columns.Add("Subtotal", Type.GetType("System.Double"))
                dtDatosMostarImportados.Columns.Add("Iva", Type.GetType("System.Double"))
                dtDatosMostarImportados.Columns.Add("Total", Type.GetType("System.Double"))

                For Each row As DataRow In datosExcel.Rows
                    Dim ProductoId As String = LTrim(RTrim(row.Item(15).ToString()))
                    renglonExcel += 1

                    If ProductoId <> "" AndAlso IsNumeric(row.Item(15)) AndAlso ProductoId <> "0" Then
                        dtDatosMostarImportados.Rows.Add()
                        dtDatosMostarImportados.Rows(NumRenglon)("RazonSocial") = LTrim(RTrim(row.Item(2).ToString()))
                        dtDatosMostarImportados.Rows(NumRenglon)("RFC") = LTrim(RTrim(row.Item(3).ToString()))
                        dtDatosMostarImportados.Rows(NumRenglon)("Observaciones") = CInt(LTrim(RTrim(row.Item(15).ToString())))
                        dtDatosMostarImportados.Rows(NumRenglon)("Concepto") = LTrim(RTrim(row.Item(17).ToString()))
                        dtDatosMostarImportados.Rows(NumRenglon)("Cantidad") = CInt(LTrim(RTrim(row.Item(20).ToString())))
                        dtDatosMostarImportados.Rows(NumRenglon)("Precio") = CDbl(LTrim(RTrim(row.Item(21).ToString())))
                        dtDatosMostarImportados.Rows(NumRenglon)("Subtotal") = CDbl(LTrim(RTrim(row.Item(22).ToString())))
                        dtDatosMostarImportados.Rows(NumRenglon)("Iva") = CDbl(LTrim(RTrim(row.Item(23).ToString())))
                        dtDatosMostarImportados.Rows(NumRenglon)("Total") = CDbl(LTrim(RTrim(row.Item(24).ToString())))
                        NumRenglon += 1
                    ElseIf renglonExcel > 1 Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Existen artículos con Id incorrecto o sin asignar, favor de verificar los datos.")
                        dtDatosMostarImportados = Nothing
                        Return dtDatosMostarImportados
                    End If
                Next
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se seleccionó ningún archivo")
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al leel la información del archivo.")
        Finally
            Cursor = Cursors.Default
        End Try

        Return dtDatosMostarImportados
    End Function

    Private Sub disenioGrid()
        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem
        DiseñoGrid.DiseñoBaseGrid(gvwListado)
        DiseñoGrid.AjustarAnchoColumnas(gvwListado)

        gvwListado.IndicatorWidth = 30
        gvwListado.OptionsView.ShowIndicator = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvwListado.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

            Select Case col.FieldName
                Case "RazonSocial"
                    col.Caption = "RECEPTOR"
                Case "Observaciones"
                    col.Caption = "PRODUCTO ID"
                Case "Concepto"
                    col.Caption = "ARTICULO"
                Case "Cantidad"
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "N0"
                    col.Width = 60

                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = col.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:N0}"
                    gvwListado.GroupSummary.Add(item)
                    col.OptionsFilter.AllowFilter = False
            End Select

            If col.FieldName = "Precio" Or col.FieldName = "Subtotal" Or col.FieldName = "Iva" Or col.FieldName = "Total" Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N2"
                col.Width = 90
            End If

            col.Caption = col.Caption.ToUpper

        Next

    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs)
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Function leerExcel() As DataTable
        Dim cnn As New OleDb.OleDbConnection
        leerExcel = New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand

        Dim ofd As New OpenFileDialog
        ofd.Filter = "CSV Files (*.csv)|*.csv"
        Dim file As String = ""

        ofd.ShowDialog()

        file = ofd.FileName

        If file = "" Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de elegir un archivo válido.")
            Return Nothing
        End If

        Dim nombreArchivo As String
        Dim rutaDis As String

        Try
            rutaDis = Path.GetDirectoryName(file)
            nombreArchivo = Path.GetFileName(file)

            cnn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & rutaDis & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"
            cnn.Open()

            cmd.Connection = cnn
            cmd.CommandText = "SELECT * FROM [" & nombreArchivo & "]"
            cmd.CommandType = CommandType.Text

            da.SelectCommand = cmd
            da.Fill(leerExcel)

            leerExcel.AcceptChanges()

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al leel la información del archivo.")
            Return Nothing
        Finally
            cnn.Close()
        End Try
    End Function

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnXML_Click(sender As Object, e As EventArgs) Handles btnXML.Click
        If blnCargaExcel Then
            cargarXML()
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario cargar el archivo Excel con los datos de la factura.")
        End If
    End Sub

    Private Sub cargarXML()
        EntXML = Nothing
        OpenFileDialog1.Filter = "xml files (*.xml)|*.xml"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True

        Dim rfcEmisorXML As String = ""
        Dim rfcReceptorXML As String = ""
        Dim versionXML As String = ""
        Dim serieXML As String = ""
        Dim folioXML As Integer = 0
        Dim fechaXML As String = ""
        Dim selloXML As String = ""
        Dim formaPagoXML As String = ""
        Dim subtotalXML As Double = 0
        Dim totalXML As Double = 0
        Dim paresXML As Integer = 0
        Dim tipoMonedaXML As String = ""
        Dim tipoComprobanteXML As String = ""
        Dim metodoPagoXML As String = ""
        Dim lugarExpedicionXML As String = ""
        Dim uuidXML As String = ""
        Dim usoCFDIXML As String = ""
        Dim impuestoXML As String = ""
        Dim tipoFactorXML As String = ""
        Dim tasaCuotaXML As Double = 0
        Dim importeImpuestoXML As Double = 0
        Dim fechaTimbradoXML As String = ""
        Dim versionSATXML As String = ""
        Dim rfcProvCertXML As String = ""
        Dim noCertSATXML As String = ""
        Dim selloSATXML As String = ""

        Dim Archivo As String = "" 'ruta

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                If System.IO.Path.GetExtension(OpenFileDialog1.FileName).ToUpper = ".XML" Then
                    Dim reader As XmlTextReader = New XmlTextReader(OpenFileDialog1.FileName)

                    Me.Cursor = Cursors.WaitCursor
                    EntXML = New Entidades.FacturaComplementoXML
                    Archivo = OpenFileDialog1.FileName 'Obtener nombre de archivo
                    
                    Do While (reader.Read())
                        If reader.Name = "cfdi:Comprobante" Or reader.Name.ToLower = "comprobante" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    Select Case reader.Name.ToLower
                                        Case "serie"
                                            serieXML = reader.Value
                                        Case "folio"
                                            folioXML = reader.Value
                                        Case "fecha"
                                            fechaXML = reader.Value
                                        Case "version"
                                            versionXML = reader.Value
                                        Case "sello"
                                            selloXML = reader.Value
                                        Case "formapago"
                                            formaPagoXML = reader.Value
                                        Case "subtotal"
                                            subtotalXML = reader.Value
                                        Case "total"
                                            totalXML = reader.Value
                                        Case "moneda"
                                            tipoMonedaXML = reader.Value
                                        Case "tipodecomprobante"
                                            tipoComprobanteXML = reader.Value
                                        Case "metodopago"
                                            metodoPagoXML = reader.Value
                                        Case "lugarexpedicion"
                                            lugarExpedicionXML = reader.Value
                                    End Select
                                End While
                            End If
                        End If

                        If reader.Name = "cfdi:Emisor" Or reader.Name.ToLower = "emisor" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name.ToUpper = "RFC" Then
                                        rfcEmisorXML = reader.Value
                                    End If
                                End While
                            End If
                        End If
                        If reader.Name = "cfdi:Receptor" Or reader.Name.ToLower = "receptor" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name.ToUpper = "RFC" Then
                                        rfcReceptorXML = reader.Value
                                    ElseIf reader.Name.ToLower = "usocfdi" Then
                                        usoCFDIXML = reader.Value
                                    End If
                                End While
                            End If
                        End If
                        If reader.Name = "tfd:TimbreFiscalDigital" Or reader.Name.ToLower = "timbrefiscaldigital" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name.ToUpper = "UUID" Then
                                        uuidXML = reader.Value
                                    ElseIf reader.Name.ToLower = "fechatimbrado" Then
                                        fechaTimbradoXML = reader.Value
                                    ElseIf reader.Name.ToLower = "version" Then
                                        versionSATXML = reader.Value
                                    ElseIf reader.Name.ToLower = "rfcprovcertif" Then
                                        rfcProvCertXML = reader.Value
                                    ElseIf reader.Name.ToLower = "nocertificadosat" Then
                                        noCertSATXML = reader.Value
                                    ElseIf reader.Name.ToLower = "sellosat" Then
                                        selloSATXML = reader.Value
                                    End If
                                End While
                            End If
                        End If
                        If reader.Name = "cfdi:Concepto" Or reader.Name.ToLower = "concepto" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name.ToLower = "cantidad" Then
                                        paresXML += reader.Value
                                    End If
                                End While
                            End If
                        End If

                        If reader.Name = "cfdi:Impuestos" Or reader.Name.ToLower = "impuestos" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute() 'cambiar  a if
                                    If reader.Name.ToLower = "totalimpuestostrasladados" Then
                                        importeImpuestoXML = reader.Value
                                    End If
                                End While
                            End If
                        End If

                    Loop

                    With EntXML
                        .PRFCEmisor = rfcEmisorXML
                        .PRFCReceptor = rfcReceptorXML
                        .PVersion = versionXML
                        .PSerie = serieXML
                        .PFolio = folioXML
                        .PFechaXML = fechaXML
                        .PSelloXML = selloXML
                        .PFormaPago = formaPagoXML
                        .PSubtotalXML = subtotalXML
                        .PTotal = totalXML
                        .PPares = paresXML
                        .PTipoMoneda = tipoMonedaXML
                        .PTipoComprobante = tipoComprobanteXML
                        .PMetodoPago = metodoPagoXML
                        .PLugarExpedicion = lugarExpedicionXML
                        .PUUID = uuidXML
                        .PUsoCFDI = usoCFDIXML
                        .PImporteImpuesto = importeImpuestoXML
                        .PFechaTimbrado = fechaTimbradoXML
                        .PVersionSAT = versionSATXML
                        .PRFCProvCert = rfcProvCertXML
                        .PNoCertSAT = noCertSATXML
                        .PSelloSAT = selloSATXML
                        .PArchivo = Archivo
                    End With

                    'Obtener el valor 
                    If Not EntXML Is Nothing AndAlso gvwListado.GetRowCellValue(0, "RFC") = EntXML.PRFCReceptor Then
                        blnCargaXML = True
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El Receptor del XML no coincide con la información del Excel.")
                        EntXML = Nothing
                        blnCargaXML = False
                    End If

                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El archivo seleccionado no es un XML.")
                End If
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al leer el XML. " & ex.ToString)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        If blnCargaXML Then
            ArchivoPDF = ""
            OpenFileDialog1.Filter = "pdf files (*.pdf)|*.pdf"
            OpenFileDialog1.FilterIndex = 2
            OpenFileDialog1.RestoreDirectory = True
            If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                If System.IO.Path.GetExtension(OpenFileDialog1.FileName).ToUpper = ".PDF" Then
                    ArchivoPDF = OpenFileDialog1.FileName
                    blnCargaPDF = True
                    If blnCargaPDF And blnCargaXML And blnCargaExcel Then
                        btnGuardar.Enabled = True
                    Else
                        btnGuardar.Enabled = False
                    End If
                Else
                    Dim objMensajeAdv As New Tools.AdvertenciaForm
                    objMensajeAdv.mensaje = "El archivo seleccionado no es un PDF."
                    objMensajeAdv.ShowDialog()
                End If
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario importar el archivo XML.")
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validaDocumentos() AndAlso validarDatos() Then
            Try
                If Not EntXML.PRFCEmisor Is Nothing AndAlso EntXML.PRFCEmisor <> "" Then
                    Dim dtRutasSICY As New DataTable
                    dtRutasSICY = objBU.obtenerRutasSICY_Emisor(EntXML.PRFCEmisor)

                    If Not dtRutasSICY Is Nothing AndAlso dtRutasSICY.Rows.Count > 0 Then
                        Dim rutaSICY_XML As String = dtRutasSICY.Rows(0).Item(0)
                        Dim rutaSICY_PDF As String = dtRutasSICY.Rows(0).Item(1)
                        Dim dtResultado As New DataTable

                        Dim vXmlCeldas As XElement = New XElement("Detalles")
                        For i As Integer = 0 To gvwListado.RowCount - 1
                            Dim vNodo As XElement = New XElement("Detalle")
                            vNodo.Add(New XAttribute("RazonSocial", gvwListado.GetRowCellValue(i, "RazonSocial")))
                            vNodo.Add(New XAttribute("RFC", gvwListado.GetRowCellValue(i, "RFC")))
                            vNodo.Add(New XAttribute("ProductoEstiloId", CInt(gvwListado.GetRowCellValue(i, "Observaciones"))))
                            vNodo.Add(New XAttribute("Concepto", gvwListado.GetRowCellValue(i, "Concepto")))
                            vNodo.Add(New XAttribute("Cantidad", CInt(gvwListado.GetRowCellValue(i, "Cantidad"))))
                            vNodo.Add(New XAttribute("Precio", CDbl(gvwListado.GetRowCellValue(i, "Precio"))))
                            vNodo.Add(New XAttribute("Subtotal", CDbl(gvwListado.GetRowCellValue(i, "Subtotal"))))
                            vNodo.Add(New XAttribute("Iva", CDbl(gvwListado.GetRowCellValue(i, "Iva"))))
                            vNodo.Add(New XAttribute("Total", CDbl(gvwListado.GetRowCellValue(i, "Total"))))
                            vXmlCeldas.Add(vNodo)
                        Next

                        Dim fechaCarpeta As String = String.Empty
                        fechaCarpeta = EntXML.PFechaTimbrado.ToString("MM") & EntXML.PFechaTimbrado.ToString("yyyy")

                        If CopiarArchivos(rutaSICY_PDF & fechaCarpeta, rutaSICY_XML & fechaCarpeta) Then
                            dtResultado = objBU.InsertarDocumentoFactura(vXmlCeldas.ToString(), EntXML, Path.GetFileName(EntXML.PArchivo), Path.GetFileName(ArchivoPDF))
                            If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
                                If dtResultado.Rows(0).Item("mensaje") = "EXITO" Then
                                    'Generar la cuenta por pagar
                                    Dim resultado As String = String.Empty
                                    resultado = GenerarCuentaPorPagar(dtResultado.Rows(0).Item("DocumentoId"))
                                    If resultado = "True" Then
                                        Try
                                            objBU.insertarRegistroComplemento(dtResultado.Rows(0).Item("DocumentoId"))
                                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se importó correctamente la factura de complemento.")
                                        Catch ex As Exception
                                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Se importó la factura de complemento, pero ocurrió un error al generar el registro en tarjeta de almacén, favor de reportarlo a sistemas.")
                                        End Try
                                        Me.Close()
                                    Else
                                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, resultado)
                                    End If
                                Else
                                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al insertar la información de la factura." & Environment.NewLine & dtResultado.Rows(0).Item("mensaje").ToString)
                                End If
                            Else
                                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se pudo obtener la información de la factura insertada.")
                            End If
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Ocurrió un error al copiar los archivos...")
                        End If
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No fue posible obtener la ruta para guardar las facturas.")
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se pudo obtener el RFC del emisor, favor de revisar que se haya cargado el XML correctamente.")
                End If
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al insertar la información de la factura.")
            End Try
        End If
    End Sub

    Public Sub CrearDirectorio(ByVal Ruta As String)

        Dim DirectorioCliente As String = String.Empty
        Dim FileName As String = String.Empty
        Dim DirectoryName As String = String.Empty
        Try
            DirectorioCliente = Path.GetDirectoryName(Ruta)
            If System.IO.Directory.Exists(DirectorioCliente) = False Then
                System.IO.Directory.CreateDirectory(DirectorioCliente)
            End If
            FileName = Path.GetFileName(Ruta)
            DirectorioCliente &= FileName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CopiarArchivos(ByVal rutaPDF As String, ByVal rutaXML As String) As Boolean
        Dim blnEnviado As Boolean = True
        Dim rutaArchivoPDF As String = String.Empty
        Dim rutaArchivoXML As String = String.Empty
        Try
            rutaArchivoPDF = rutaPDF & "\" & Path.GetFileName(ArchivoPDF)
            rutaArchivoXML = rutaXML & "\" & Path.GetFileName(EntXML.PArchivo)

            CrearDirectorio(rutaArchivoPDF)
            File.Copy(ArchivoPDF, rutaArchivoPDF, True)
            CrearDirectorio(rutaArchivoXML)
            File.Copy(EntXML.PArchivo, rutaArchivoXML, True)
        Catch ex As Exception
            blnEnviado = False
        End Try
        Return blnEnviado
    End Function

    Private Function GenerarCuentaPorPagar(ByVal idDocumento As Integer) As String
        Dim resultado As String = String.Empty
        Try

            Dim idcomprobantesicy As Integer = 0
            Dim objBUCFD As New Proveedores.BU.AdmonDoctosComprasPT_BU
            Try
                idcomprobantesicy = objBUCFD.ObtenerIdComprobanteCFD(idDocumento)
            Catch ex As Exception
            End Try

            Dim dtResultado As New DataTable

            dtResultado = objBU.ObtenerInfoCXPSaldo(idDocumento)
            If Not dtResultado Is Nothing Then
                If dtResultado.Rows.Count > 0 Then
                    Dim tipoDoc As Integer
                    Dim idProveedor As Integer
                    Dim numDoc As String
                    Dim fechaDoc As Date
                    Dim fechaVencimiento As Date
                    Dim semanaPago As Integer
                    Dim semanaPagada As Integer
                    Dim subTotal As Double
                    Dim iva As Double
                    Dim total As Double
                    Dim totalDoc As Double
                    Dim moneda As Integer
                    Dim nave As Integer
                    Dim añoSemPago As Integer
                    Dim rfcContribuyente As String
                    Dim rfcProveedor As String
                    Dim giro As String
                    ''Dim idcomprobantesicy As Integer
                    Dim objBU As New Proveedores.BU.AdmonDoctosComprasPT_BU

                    tipoDoc = CInt(dtResultado.Rows(0)("tipoDoc").ToString)
                    idProveedor = CInt(dtResultado.Rows(0)("idProveedor").ToString)
                    numDoc = dtResultado.Rows(0)("numDoc").ToString
                    fechaDoc = CDate(dtResultado.Rows(0)("fechaDoc").ToString)
                    fechaVencimiento = CDate(dtResultado.Rows(0)("fechaVencimiento").ToString)
                    semanaPago = CInt(dtResultado.Rows(0)("semanaPago").ToString)
                    semanaPagada = CInt(dtResultado.Rows(0)("semanaPagada").ToString)
                    subTotal = CDbl(dtResultado.Rows(0)("subTotal").ToString)
                    iva = CDbl(dtResultado.Rows(0)("iva").ToString)
                    total = CDbl(dtResultado.Rows(0)("total").ToString)
                    totalDoc = CDbl(dtResultado.Rows(0)("totalDoc").ToString)
                    moneda = CInt(dtResultado.Rows(0)("moneda").ToString)
                    nave = CInt(dtResultado.Rows(0)("nave").ToString)
                    añoSemPago = CInt(dtResultado.Rows(0)("añoSemPago").ToString)
                    rfcContribuyente = dtResultado.Rows(0)("rfcContribuyente").ToString
                    rfcProveedor = dtResultado.Rows(0)("rfcProveedor").ToString
                    giro = dtResultado.Rows(0)("giro").ToString
                    'idcomprobantesicy = CInt(dtResultado.Rows(0)("idcomprobantesicy").ToString)

                    resultado = objBU.InsertarCXPSaldo(tipoDoc, idProveedor, numDoc, fechaDoc, fechaVencimiento, semanaPago, semanaPagada, subTotal, iva, total, totalDoc, moneda, nave, añoSemPago, rfcContribuyente, rfcProveedor, giro, idcomprobantesicy)
                    If resultado <> "True" Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, resultado)
                    End If
                Else
                    'Show_message("Advertencia", "No se pudo obtener la información para generar la cuenta por pagar")
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se pudo obtener la información para generar la cuenta por pagar")
                End If
            Else
                'Show_message("Advertencia", "No se pudo obtener la información para generar la cuenta por pagar")
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se pudo obtener la información para generar la cuenta por pagar")
            End If
        Catch ex As Exception
            'Show_message("Advertencia", ex.Message)
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
        End Try
        Return resultado
    End Function

    Private Function validaDocumentos() As Boolean
        Dim blnValidaDoctos As Boolean = True
        If gvwListado.RowCount <= 0 Then
            blnValidaDoctos = False
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se cargó ningún registro para la factura, favor de seleccionar nuevamente el archivo Excel.")
        ElseIf ArchivoPDF.Trim = "" Or ArchivoPDF Is Nothing Then
            blnValidaDoctos = False
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se cargó correctamente el archivo PFD, favor de seleccionarlo nuevamente.")
        ElseIf EntXML Is Nothing Then
            blnValidaDoctos = False
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se cargó correctamente el archivo XML, favor de seleccionarlo nuevamente.")
        ElseIf objBU.validarExisteFacturaComplemento(EntXML.PRFCEmisor, EntXML.PSerie, EntXML.PFolio) Then 'VALIDAR SI LA FACTURA NO EXISTE YA EN EL SISTEMA... 
            blnValidaDoctos = False
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La factura ya se encuentra en el sistema, favor de validar.")
        End If

        Return blnValidaDoctos
    End Function

    Private Function validarDatos() As Boolean
        Dim blnValidaDatos As Boolean = True
        Dim totalFactura As Double = 0
        Dim totalPres As Integer = 0
        Dim blnValidaId As Boolean = True
        Dim blnValidaPrecios As Boolean = True

        For i As Integer = 0 To gvwListado.RowCount - 1
            If Not IsDBNull(gvwListado.GetRowCellValue(i, "Total")) Then
                totalFactura += gvwListado.GetRowCellValue(i, "Total")
            End If

            If Not IsDBNull(gvwListado.GetRowCellValue(i, "Cantidad")) Then
                totalPres += gvwListado.GetRowCellValue(i, "Cantidad")
            End If

            If Not IsDBNull(gvwListado.GetRowCellValue(i, "Observaciones")) Then
                If gvwListado.GetRowCellValue(i, "Observaciones").ToString.Trim = "" Or gvwListado.GetRowCellValue(i, "Observaciones").ToString.Trim = "0" Then
                    blnValidaId = False
                End If
            Else
                blnValidaId = False
            End If

            If Not IsDBNull(gvwListado.GetRowCellValue(i, "Precio")) Then
                If gvwListado.GetRowCellValue(i, "Precio").ToString.Trim = "" Or CDbl(gvwListado.GetRowCellValue(i, "Precio")) <= 0 Then
                    blnValidaPrecios = False
                End If
            Else
                blnValidaPrecios = False
            End If

        Next

        If blnValidaId = False Then
            blnValidaDatos = False
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Existen artículos con Id incorrecto o sin asignar, favor de verificar los datos.")
        ElseIf blnValidaPrecios = False Then
            blnValidaDatos = False
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Existen artículos con precios incorrectos o sin asignar, favor de verificar los datos.")
        ElseIf totalPres <> EntXML.PPares Then
            blnValidaDatos = False
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Hay una diferencia de " & CStr(totalPres - EntXML.PPares) & " pares.")
        ElseIf Math.Round(totalFactura, 2) <> EntXML.PTotal Then
            blnValidaDatos = False
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Hay una diferencia de " & CStr(totalFactura - EntXML.PTotal) & " pesos.")
        End If

        Return blnValidaDatos
    End Function

End Class